    public partial class Main : Form
    {
        clsDB x = new clsDB();
        public Main()
        {
            InitializeComponent();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            x.SQLDB("insert into tbl_info (u_lastname, u_firstname, u_middlename) values ('" + atxtLN.Text + "','" + atxtFN.Text + "','" + atxtFN.Text + "')");
            fillgrid();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            x.SQLDB(" select * from tbl_info ");
            dgv1.DataSource = x.mDataSet.Tables[0];
            fillgrid();
        }
        void fillgrid()
        {
            x.SQLDB("select * from tbl_info");
            dgv1.DataSource = null;
            dgv1.DataSource = x.mDataSet.Tables[0];
        }
        void search()
        {
            x.SQLDB("SELECT * from tbl_info where u_id  like '" + etxtID.Text + "%' order by u_id");
            if (x.mDataSet.Tables[0].Rows.Count > 0)
            {
                x.mDataAdapter.Fill(x.mDataSet, "tbl_info");
                dgv1.DataSource = x.mDataSet.Tables["tbl_info"].DefaultView;
                etxtLN.Text = dgv1.Rows[dgv1.CurrentRow.Index].Cells["u_lastname"].Value.ToString();
                etxtFN.Text = dgv1.Rows[dgv1.CurrentRow.Index].Cells["u_firstname"].Value.ToString();
                etxtMN.Text = dgv1.Rows[dgv1.CurrentRow.Index].Cells["u_middlename"].Value.ToString();
            }
            else if (etxtID.Text == "Type User ID to Edit")
            {
                etxtLN.Text = "";
                etxtFN.Text = "";
                etxtMN.Text = "";
            }
            else
            {
                etxtLN.Text = "";
                etxtFN.Text = "";
                etxtMN.Text = "";
            }
        }
        private void etxtID_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void etxtID_Enter(object sender, EventArgs e)
        {
            etxtID.Text = "";
            etxtID.ForeColor = Color.Black;
        }
        private void etxtID_Leave(object sender, EventArgs e)
        {
            if (etxtID.Text == "")
            {
                etxtID.ForeColor = Color.Gray;
                etxtID.Text = "Type User ID to Edit";
                
                x.SQLDB(" select * from tbl_info ");
                dgv1.DataSource = x.mDataSet.Tables[0];
                fillgrid();
            }
        }
        private void etxtID_KeyUp(object sender, KeyEventArgs e)
        {
            search();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            x.SQLDB("UPDATE tbl_info set u_lastname ='" + etxtLN.Text + "', u_firstname ='" + etxtFN.Text + "', u_middlename ='" + etxtMN.Text + "' where u_id =" + etxtID.Text);
            MessageBox.Show("Operation Successful!");
            fillgrid();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            x.SQLDB("delete from tbl_info where u_id =" + dtxtID.Text + "");
            MessageBox.Show("Operation Successful!");
            fillgrid();
        }
    }
}
