    var result = new Dictionary<string, object>();
    var type = typeof (System.Windows.SystemParameters);
    var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Static);
    foreach(var property in properties)
    {
        result.Add(property.Name, property.GetValue(null, null));
    }
    foreach(var pair in result)
    {
        Console.WriteLine("{0} : {1}", pair.Key, pair.Value);
    }
