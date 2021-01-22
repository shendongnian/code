    public string passwordChange(string username, string password, string newPasswd)
    {
        string SQLQuery = "SELECT password FROM LoginAccount WHERE username = @username";
        string SQLQuery1 = "UPDATE LoginAccount SET password = @newPassword  WHERE username = @username";
        SqlCommand command = new SqlCommand(SQLQuery, sqlConnection);
        command.Parameters.AddWithValue("@username", username);
    
        SqlCommand command1 = new SqlCommand(SQLQuery1, sqlConnection);
        command1.Parameters.AddWithValue("@username", username);
        command1.Parameters.AddWithValue("@newPassword", newPasswd);
    
        sqlConnection.Open();
        string sqlPassword = "";
        SqlDataReader reader;
    
        try
        {
            reader = command.ExecuteReader();
    
    
            if (reader.Read())
            {
                if (!reader.IsDBNull(0))
                {
                    sqlPassword = reader["password"].ToString();
                }
            }
            reader.Close();
    
            if (sqlPassword.ToString() == password.ToString())
            {
                try
                {
                    int flag = 0;
                    flag = command1.ExecuteNonQuery();
    
                    if (flag > 0)
                    {
                        sqlConnection.Close();
                        return "Password Changed Successfully";
                    }
                    else
                    {
                        sqlConnection.Close();
                        return "User Password could not be changed";
                    }
                }
                catch (Exception exr)
                {
                    sqlConnection.Close();
                    return "Password Could Not Be Changed Please Try Again";
                }
            }
            else
            {
                sqlConnection.Close();
                return "User Password does not Match";
            }
        }
        catch (Exception exr)
        {
            sqlConnection.Close();
            return "User's Password already exists";
        }
    }
