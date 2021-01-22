    while (reader.Read())
    {
        string name = reader.GetString(0);
        Console.WriteLine("Read name: {0}", name);
    }
