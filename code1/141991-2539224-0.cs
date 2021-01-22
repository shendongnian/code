    Dictionary<int, string> dictionary = new Dictionary<int, string>();
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
    
        using (SqlCommand command = new SqlCommand(queryString, connection))
        {
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    dictionary.Add(reader.GetInt32(0), reader.GetString(1));
                }
            }
        }
    }
    
    // do something with dictionary
