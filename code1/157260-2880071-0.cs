    using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BAR"].ConnectionString))
    using (var cmd = conn.CreateCommand())
    {
        conn.Open();
        cmd.Connection = conn;
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.CommandText = "SP_YOUR_PROC";
        cmd.ExecuteNonQuery();
    }
