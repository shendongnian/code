    List<string> Users = new List<string>();
    using (SqlDataReader reader = command.ExecuteReader())
    {
        while (reader.Read())
        {
            Users.Add(reader[0].ToString());
        }
    }
