    using (var conn = new SqlConnection(ConnectionString))
    {
        using (var cmd = conn.CreateCommand())
        {
            cmd.CommandText = "[dbo].[Save]";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter(
                "Identity", SqlDbType.NVarChar, 10) { Value = item.Identity });
            cmd.Parameters.Add(new SqlParameter(
                "Name", SqlDbType.NVarChar, 50) { Value = item.Name});
            conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            finally 
            {
                conn.Close();
            }
        }
    }
    return item;
