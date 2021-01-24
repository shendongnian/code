    //Need to provide email and password to this method
    public void Login(string email, string password)
    {
        const string query = "SELECT 1 FROM UsersTBL WHERE Email = @email AND UserPassword = @password";
        if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(password))
        {
            //Shouldn't need to create an instance of a Form simply to query the database
            SqlConnection con = null;
            using (var login = new LoginWindow())
                con = login.con;
            try
            {
                con.Open();
                var com = con.CreateCommand();
                com.CommandText = query;
                //Correct types if not VARCHAR
                com.Parameters.Add("@email", SqlDbType.VarChar);
                com.Parameters["email"].Value = email;
                com.Parameters.Add("@password", SqlDbType.VarChar);
                //Should NOT be storing passwords as plain text in the database
                com.Parameters["password"].Value = password;
                if (com.ExecuteScalar() == 1)
                {
                    AppWindow a = new AppWindow();
                    a.Show();
                }
            }
            catch (Exception e)
            {
                 //log e somehow
            }
            finally
            {
                 //Close the connection if still open
                 if (con != null && con.State != ConnectionState.Closed)
                     con.Close();
            }
        }
    }
