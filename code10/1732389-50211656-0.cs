    var userIds = new List<int>();
    using (var reader = command.ExecuteReader())
    {
        while (reader.Read())
        {
            userIds.Add(int.Parse(reader["userid"].ToString()));
        }
    }
