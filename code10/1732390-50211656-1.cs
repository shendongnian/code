    var userIds = new List<int>();
    using (var reader = command.ExecuteReader())
    {
        while (reader.Read())
        {
            userIds.Add(reader.GetInt32(0));
        }
    }
