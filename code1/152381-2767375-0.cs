    using (var conn = new SqlConnection(ConnectionString))
    using (var cmd = conn.CreateCommand())
    {
        conn.Open();
        cmd.CommandText = "SELECT isset_field FROM sometable";
        using (var reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                bool isSet = reader.GetBoolean(0);
            }
        }
    }
