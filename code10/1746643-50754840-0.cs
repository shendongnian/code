    using (SqlDataReader reader = command.ExecuteReader())
    {
        while (reader.Read())
        {
            //var nameReturned = reader.GetName(0);
            //nameString = nameReturned.ToString();
            nameString = reader[0].ToString();
        }
    }
