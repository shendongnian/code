    List<int> results = new List<int>();
    using (SqlDataReader reader = command.ExecuteReader())
    {
        if (reader.Read())
        {
            results.Add((int)reader["userid"]));
        }
    }
    // use results
