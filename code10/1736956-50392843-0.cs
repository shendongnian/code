        string cmdText = "select 1 from mytbl1";         
        using (var sqlConnection = new SqlConnection(connString))
        {
            using (var sqlCmd = new SqlCommand(cmdText, sqlConnection))
            {                    
                try
                {  
                 sqlConnection.Open();                    
                 return Convert.ToInt32(sqlCmd.ExecuteScalar()) == 1;
                }
                catch(SqlException ex)
                {
                }
            }
        }      
