t.GetFields(BindingFlags.Static | BindingFlags.Public)
    
    foreach (var field in typeof(NodeHeaders).GetFields(BindingFlags.Static | BindingFlags.Public))
    {        
        // Get the name of the property
        string fieldName = field.Name;
        // Get the value of the property
        object propertyValue = field.GetValue(null);
        Console.WriteLine("test3");
        Console.WriteLine(fieldName + ": " + (propertyValue == null ? "null" : propertyValue.ToString()));
    }
