    string connstring = @"Data Source=KALKI\SQLEXPRESS;Initial Catalog=AZaZeDB;Integrated Security=True";
    public int CreateUser(string Username, string Password)
        {
            using (SqlConnection con = new SqlConnection(connstring))
            {
                con.Open();
                try
                {
                    SqlCommand sqlcmd = new SqlCommand("SELECT COUNT(*) from users where username = @username", con);
                    sqlcmd.Parameters.Add(new SqlParameter("@username", Username));
                    int userCount = (int)sqlcmd.ExecuteScalar();
                    if (userCount > 0)
                    {
                        return 1;
                    }
                    else
                    {
                        
                        return MakeUser(Username, Password);
                    }
                }
                catch (SqlException e)
                {
                    string strErrorMessage = e.Message;
                    throw;
                }
            }
        }
