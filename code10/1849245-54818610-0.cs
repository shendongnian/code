    while (reader.Read())
    {
        string action = reader.GetString(0);
        if (action == "INSERT")
        {
            int oldId = reader.GetInt32(1);
            int newId = reader.GetInt32(2);
            // Now do what you want with them.
        }
    }
