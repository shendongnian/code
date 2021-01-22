    // List all public properties for the given type
    PropertyInfo[] properties = foo.GetType().GetProperties();
    foreach (var property in properties)
    {
        string propertyName = property.Name;
    }
