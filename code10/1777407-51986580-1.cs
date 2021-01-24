    public string userLogin()
    {
        string connStr = ConfigurationManager.ConnectionStrings["SRJDconnstr"].ToString();
        string cmdStr = @"SELECT dbo.USER_LOGIN(@USER_NAME, @PWD)";
    
        using (SqlConnection conn = new SqlConnection(connStr))
        using (SqlCommand cmd = new SqlCommand(cmdStr, conn))
        {
                conn.Open();
    			
                cmd.Parameters.AddWithValue("@USER_NAME", TB_USER_NAME.Text);
                cmd.Parameters.AddWithValue("@PWD", TB_PWD.Text);
    
                var result = cmd.ExecuteScalar();
    
                return result.ToString();
        }
    }
