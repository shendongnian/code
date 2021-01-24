     public partial class CryptSeed : Form
    {
        public CryptSeed()
        {
            InitializeComponent(); 
        }
           //you will need to specify the port Mysql uses:3306
       
        private void Form1_Load(object sender, EventArgs e)
        {      
               //  If you are saving data you cant do it here.
              //  But still will show you how to do it in a button //click 
         //event.                
        }
        private void button1_Click(object sender,EventArgs e)
        {MySqlConnection con = new MySqlConnection("server=localhost;port=3306;  username=seedcrypt;database=seed;password=xxxxxxx");
               string query = "INSERT INTO 
              info('id','seed','password','ip') VALUES 
             (NULL,'"+seed.Text+ "','" +password.Text+ "',NULL)";
             con.Open();
              MysqlCommand cmd = new 
              MysqlCommand(query,con);
              cmd.ExecuteNonQuery();
               con.Close();
              MessageBox.Show("INSERTED SUCCESSFULLY !!! 
                ");
        }
    }
}
