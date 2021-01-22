    public bool IsLoginSuccess(string userName, string password)
    {
        try
        {
            SqlConnection SQLCon = new SqlConnection(WebConfigurationManager.ConnectionStrings["SqlConnector"].ConnectionString);
            SqlCommand sqlcomm = new SqlCommand();
            SQLCon.Open();
            sqlcomm.CommandType = CommandType.StoredProcedure;
            sqlcomm.CommandText = "spLoginCheck"; // Stored Procedure name
            sqlcomm.Parameters.AddWithValue("@Username", userName); // Input parameters
            sqlcomm.Parameters.AddWithValue("@Password", password); // Input parameters
                         
            // Your output parameter in Stored Procedure           
            var returnParam1 = new SqlParameter
            {
                ParameterName = "@LoginStatus",
                Direction = ParameterDirection.Output,
                Size = 1                    
            };
            sqlcomm.Parameters.Add(returnParam1);
    
            // Your output parameter in Stored Procedure  
            var returnParam2 = new SqlParameter
            {
                ParameterName = "@Error",
                Direction = ParameterDirection.Output,
                Size = 1000                    
            };
    
            sqlcomm.Parameters.Add(returnParam2);
                    
            sqlcomm.ExecuteNonQuery(); 
            string error = (string)sqlcomm.Parameters["@Error"].Value;
            string retunvalue = (string)sqlcomm.Parameters["@LoginStatus"].Value;                    
        }
        catch (Exception ex)
        {
    
        }
        return false;
    }
