    Type type = typeof(Person);
    foreach (var field in type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
    {
        foreach (var attr in field.GetCustomAttributes(false))
        {
            Console.WriteLine("Field {0}: attribute {1}", field, attr);
        }
    }
    foreach (var property in type.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
    {
        foreach (var attr in property.GetCustomAttributes(false))
        {
            Console.WriteLine("Property {0}: attribute {1}", property, attr);
        }
    }
    foreach (var method in type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
    {
        foreach (var attr in method.GetCustomAttributes(false))
        {
            Console.WriteLine("Method {0}: attribute {1}", method, attr);
        }
    }
