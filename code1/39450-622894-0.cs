    public void Foo<T>(T parameters)
    {
        var dict = typeof(T).GetProperties()
            .ToDictionary(p => p.Name, 
                p => p.GetValue(parameters, null));
        if (dict.ContainsKey("Message"))
        {
            Console.WriteLine(dict["Message"]);
        }
    }
