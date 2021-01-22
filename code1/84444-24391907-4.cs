    public partial class Login : Form
    {
        clsDB x = new clsDB();
        public Login()
        {
            InitializeComponent();
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
                x.SQLDB("select * from tbl_accounts where u_username ='" + txtUser.Text + "' and u_password ='" + txtPass.Text + "'");
                if (x.mDataSet.Tables[0].Rows.Count > 0)
                {
                    Main a = new Main();
                    this.Hide();
                    a.Show();
                }
                else
                {
                    MessageBox.Show("wrong username or password");
                }
        }
