    public partial class login : Form
    {
        SqlConnection cn = new SqlConnection("connection string here");
        
        public login()
        {
            InitializeComponent();
            
        }
       
        private void freshrationpurchase_Load(object sender, EventArgs e)
        {
           
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cn.Open();
            cmd.CommandText = "select count( *) from user where id=@";
            SqlDataReader dr;
	    dr=cmd.ExecuteReader();
            cn.Close();
            
        }
    }
}
