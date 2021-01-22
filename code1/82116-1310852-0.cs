    foreach (PropertyInfo property in typeof(Properties.Resources).GetProperties
        (BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
    {
        Console.WriteLine("{0}: {1}", property.Name, property.GetValue(null, null));
    }
