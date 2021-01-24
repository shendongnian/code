    using (SqliteCommand cmd = new SqliteCommand(sQuery, m_Conn))
    {
        using (SqliteDataReader reader = cmd.ExecuteReader())
        {
            if (reader.Read())
            {
                ret_type = reader.GetInt32(0);
            }
        }
    }
