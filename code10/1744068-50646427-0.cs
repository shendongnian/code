    var idList = new List<string>();
    using (SqlDataReader reader = command.ExecuteReader())
    {
        while (reader.Read())
        {
            idList.Add(reader.GetString(0));
        }
    }
