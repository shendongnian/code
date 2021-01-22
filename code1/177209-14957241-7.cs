    public override object ExecuteScalar()
    {
        lastInsertedId = -1;
        object val = null;
        #if !CF
        // give our interceptors a shot at it first
        if (connection != null &&
            connection.commandInterceptor.ExecuteScalar(CommandText, ref val))
            return val;
        #endif
        using (MySqlDataReader reader = ExecuteReader())
        {
            if (reader.Read())
                val = reader.GetValue(0);
        }
        return val;
    }
