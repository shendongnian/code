    public static int ExecSQL(string sqlConnString, System.Data.SqlClient.SqlCommand cmd)
    { 
        int rowsAffected;
        try
        {
            using (SqlConnection conn = new SqlConnection(sqlConnString))
            {
                conn.Open();
                cmd.Connection = conn;
                rowsAffected = cmd.ExecuteNonQuery();
            }
        } finally {
            cmd.Dispose();
        }
        return rowsAffected;
    }
