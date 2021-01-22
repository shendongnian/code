    public static int ExecProcedure(string sqlConnString, string procedureName)
    {
        using (var cmd = new System.Data.SqlClient.SqlCommand())
        {
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = procedureName;
            int rowsAffected;
            using (SqlConnection conn = new SqlConnection(sqlConnString))
            {
                conn.Open();
                cmd.Connection = conn;
                return cmd.ExecuteNonQuery();
            }
        }
    }
