    public void FirstMethod()
    {
        using (var command = connection.CreateCommand())
        {
            command.CommandText = "...";
            using (var reader = command.ExecuteReader())
            {
                // do something with the data
                SecondMethod(reader);
            }
        }
    }
    public void SecondMethod(var reader)
    {
        // do stuff with reader...
    }
