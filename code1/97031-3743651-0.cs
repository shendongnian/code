    using (var conn = new MySqlConnection(DBConnectionString))
    using (var cmd = conn.CreateCommand())
    {
        conn.Open();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_name";
        cmd.Parameters.Add(new SqlParameter("@foundationId", foundationId));
        cmd.Parameters.Add(new SqlParameter("@fpids", fpids));
        ...
        
        using (var reader = cmd.ExecuteReader())
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                columns.Add(reader.GetName(i));
            }
        }
    }
