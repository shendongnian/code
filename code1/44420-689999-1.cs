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
            cmd.Parameters.Add(new SqlParameter(
                "Title", SqlDbType.NVarChar, 100) { Value = item.Title});
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
    return item;
