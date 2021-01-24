    using (var reader = command.ExecuteReader())
    {
        while (reader.Read())
        {
            // Access your data here
            Console.WriteLine(String.Format("{0}", reader[0])); // Column AddressID
            // ...
        }
    }
