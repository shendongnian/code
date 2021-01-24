    public bool Login(SqlConnection con, string email, string password)
    {
        const string query = "SELECT 1 FROM UsersTBL WHERE Email = @email AND UserPassword = @password";
        if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(password))
        {
            try
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = query;
                //Correct SqlDbTypes if necessary
                cmd.Parameters.Add("@email", SqlDbType.VarChar);
                cmd.Parameters["@email"].Value = email;
                cmd.Parameters.Add("@password", SqlDbType.VarChar);
                //Should NOT be storing passwords as plain text in the database
                cmd.Parameters["@password"].Value = password;
                if (cmd.ExecuteScalar() == 1)
                    return true;
            }
            catch (Exception e)
            {
                 //log e somehow or eliminate this catch block
            }
            finally
            {
                 //Close the connection if still open
                 if (con != null && con.State != ConnectionState.Closed)
                     con.Close();
            }
        }
        return false;
    }
