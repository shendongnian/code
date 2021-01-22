    try
        {
            using (System.Data.SqlClient.SqlConnection conn = new SqlConnection(connectionString))
            {
    
                conn.Open();
    
                return conn.State == System.Data.ConnectionState.Open;
            }
        }
        catch (SqlException)
        {
            // There was an error in opening the database so it is must not up.
            return false;
        }
