    conn.Open();
    using (SqlCommand cmd = new SqlCommand("usp_ReadName",conn))
    {
        cmd.CommandType = CommandType.StoredProcedure;
        if (id.HasValue)
            cmd.Parameters.Add("@name_id", SqlDbType.BigInt).Value = id.Value;
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    dte.name_data item = new dte.name_data(
                        (long)reader["name_id"],
                        reader["name"].ToString(),
                        reader["description"].ToString());
                    items.Add(item);
                }
            }
        }
    }
