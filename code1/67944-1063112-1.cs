    public static void ExecuteReaderWithCommand(SqlCommand command,
        Action<SqlDataReader> action)
    {
        using (SqlDataReader dataReader = thisCommand.ExecuteReader())
        {
            while (reader.Read())
            {
                action(reader);
            }
        }
    }
