t.GetFields(BindingFlags.Static | BindingFlags.Public)
    
     
    // Use each property of the object passed in
    foreach (var field in typeof(NodeHeaders).GetFields(BindingFlags.Static | BindingFlags.Public))
    {
        string fieldName;
        object propertyValue;
        // Get the name of the property
        fieldName = field.Name;
        // Get the value of the property
        propertyValue = field.GetValue(null);
        Console.WriteLine("test3");
        Console.WriteLine(fieldName + ": " + (propertyValue == null ? "null" : propertyValue.ToString()));
    }
