    public class user
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MailAddress{ get; set; }
    }
    //You can keep your Logged user in a static class
    public static class PublicParameters
    { 
      public static User CurrentUser;
      //Define only one connection string in your application.
      public static string ConnectionString= @"Data Source=   (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated 
     Security=True;"
    }
  
   
        void Login()
        {
            using (SqlConnection sqlConn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlComm = new SqlCommand("FROM tbl WHERE Username=@Username AND Password=@Password", sqlConn))
                {
                    if (sqlComm.Connection.State == System.Data.ConnectionState.Closed)
                        sqlComm.Connection.Open();
                    SqlDataReader sqlRd = sqlComm.ExecuteReader();
                    sqlComm.Parameters.AddWithValue("@Username", txtbxUsername.Text);
                    sqlComm.Parameters.AddWithValue("@Password", pswbxPassword.Password);
                    //Your username column must be unique
                    while (sqlRd.Read())
                    {
                        PublicParameters.CurrentUser = new Controllers.User();
                        PublicParameters.CurrentUser.FirstName = sqlRd["FirstName"].ToString();
                        PublicParameters.CurrentUser.LastName = sqlRd["LastName"].ToString();
                        PublicParameters.CurrentUser.MailAddress = sqlRd["MailAddress"].ToString();
                        //And other properties to assign
                    }
                    if(PublicParameters.CurrentUser != null)
                    {
                        MessageBox.Show("Login successfully!");
                        //Yo have your logged user 
                    }
                    else
                    {
                        MessageBox.Show("Username or password is incorrect");
                    }
                }
            }
        }
