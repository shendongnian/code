        Type type = typeof(Benefits);
        PropertyInfo[] properties = type.GetProperties();
        foreach (PropertyInfo property in properties)
        {
             // your logic here
            Console.WriteLine("{0} = {1}", property.Name, property.GetValue(benefitsInstance, null));
        }
        Console.Read();
