    public int CreateUser(string Username, string Password)
        {         
            using (SqlConnection con = new SqlConnection(Con))
            {
                con.Open();
                try
                {
                    SqlCommand sqlcmd = new SqlCommand("SELECT COUNT(*) from users where username like '%' + @username + '%'", con);
                    sqlcmd.Parameters.AddWithValue("@username", Username);
                    int userCount = (int)sqlcmd.ExecuteScalar();
                    if (userCount > 0)
                    {
                        return 1;
                    }
                    else
                    {
                        MakeUser(Username, Password);
                        return 0;
                    }
                }
                catch (SqlException e)
                {
                    String strErrorMessage = e.Message;
                    throw;
                }
            }
        }
