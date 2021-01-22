    Dictionary<int, string> dictionary;
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        using (SqlCommand command = new SqlCommand(queryString, connection))
        using (SqlDataReader reader = command.ExecuteReader())
        {
            dictionary = reader.Cast<DbDataRecord>()
                               .ToDictionary(row => (int)row["id"], row => (string)row["name"]);
        }
    }
