    private static void PrintMetadata(Test item)
    {
        Type type = item.GetType();
    
        FieldInfo[] fields = type.GetFields(BindingFlags.GetField | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        foreach (var field in fields)
        {
            Console.WriteLine(field.Name + " :: " + field.GetValue(item));
        }
    
        PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.GetProperty);
        foreach (var property in properties)
        {
            Console.WriteLine(property.Name + " :: " + property.GetValue(item));
        }
    }
