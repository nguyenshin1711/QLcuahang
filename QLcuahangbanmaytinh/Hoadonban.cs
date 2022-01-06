using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLcuahangbanmaytinh
{
    public partial class frmhoadonban : Form
    {
        public frmhoadonban()
        {
            InitializeComponent();
        }
        ConnectCSDL co = new ConnectCSDL();
        public void LoadData()
        {
            co.KetNoi();
            dgvDShdb.DataSource = co.GetData("select * from tblHoadonban");
            co.NgatKetNoi();
        }

        private void frmhoadonban_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadData();
            cbomamaytinh.DataSource = co.GetData("select * from tblThongTinMT");
            cbomamaytinh.ValueMember = "MaMT";
            cbomamaytinh.DisplayMember = "MaMT";
           
            cbomakh.DataSource = co.GetData("select * from tblKhachhang");
            cbomakh.ValueMember = "MaKH";
            cbomakh.DisplayMember = "MaKH";

         
           
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            this.txtdongia.Clear();
            this.txtmahoadonban.Clear();
            this.txtmanv.Clear();
            this.txtsodienthoai.Clear();
            this.txtdiachi.Clear();

            this.txtsoluong.Clear();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            double soluong = double.Parse(txtsoluong.Text);
            double dongia = double.Parse(txtdongia.Text);
            double tongtien = soluong * dongia;
            txtTongtien.Text = tongtien.ToString();
            co.KetNoi();
            string sqlthem = "insert into tblHoadonban values ('" + txtmahoadonban.Text + "','" + txtmanv.Text + "','" + cbomakh.SelectedValue + "','" + cbomamaytinh.SelectedValue + "','" + txtsoluong.Text + "','"+mtbNgayban.Text+"','" + txtdiachi.Text + "','" + txtsodienthoai.Text + "','" + txtdongia.Text + "','" + txtTongtien.Text + "')";
            co.ThucThi(sqlthem);
            frmhoadonban_Load(sender, e);
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc muốn xóa không?", "Trả lời",
           MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
            {
                string sqlxoa = "delete from tblHoadonban where MaHDB = '" + txtmahoadonban.Text + "'";
                co.ThucThi(sqlxoa);
            }
            frmhoadonban_Load(sender, e);

          
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc muốn thoát không?", "Trả lời",
           MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                Application.Exit();
        }

        private void btnquaylai_Click(object sender, EventArgs e)
        {
            frmMenu tc = new frmMenu();
            tc.Show();
            this.Hide();
        }

        private void dgvDShdb_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtmahoadonban.Text = dgvDShdb.Rows[i].Cells[0].Value.ToString().Trim();
            txtmanv.Text = dgvDShdb.Rows[i].Cells[1].Value.ToString().Trim();
            cbomakh.Text = dgvDShdb.Rows[i].Cells[2].Value.ToString().Trim();
            cbomamaytinh.Text = dgvDShdb.Rows[i].Cells[3].Value.ToString().Trim();
            txtsoluong.Text = dgvDShdb.Rows[i].Cells[4].Value.ToString().Trim();

            txtdiachi.Text = dgvDShdb.Rows[i].Cells[6].Value.ToString().Trim();
            txtsodienthoai.Text = dgvDShdb.Rows[i].Cells[7].Value.ToString().Trim();
            txtdongia.Text = dgvDShdb.Rows[i].Cells[8].Value.ToString().Trim();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            double soluong = double.Parse(txtsoluong.Text);
            double dongia = double.Parse(txtdongia.Text);
            double tongtien = soluong * dongia;
            txtTongtien.Text = tongtien.ToString();
            co.KetNoi();
            string sqlsua = "update tblHoadonban set MaHDB='" + txtmahoadonban.Text + "',MaNV='" + txtmanv.Text + 
                "',MaKH='" + cbomakh.SelectedValue + "',MaMT='" + cbomamaytinh.SelectedValue + 
                "',Soluong='" + txtsoluong.Text + "',Ngayban='" + mtbNgayban.Text + "',Diachi='" + txtdiachi.Text + 
                "',sdt='" + txtsodienthoai.Text + "',Dongia='" + txtdongia.Text + "',Tongtien='" + txtTongtien.Text + "' where MaHDB='" + txtmahoadonban.Text + "'";
            co.ThucThi(sqlsua);
            LoadData();
            
        }
       

        

        public void loaddata()
        {
            co.KetNoi();
            dgvDShdb.DataSource = co.GetData("select * from tblHoadonban");
            co.NgatKetNoi();
        }

        private void grphoadonban_Enter(object sender, EventArgs e)
        {

        }

    }
}
