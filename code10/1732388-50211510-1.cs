    List<int> results = new List<int>();
    using (SqlDataReader reader = command.ExecuteReader())
    {
        while (reader.Read())
        {
            results.Add((int)reader["userid"]));
        }
    }
    // use results
