    var type = typeof(WindowManager);
    PropertyInfo property;
    foreach (var prop in path.Split('.'))
    {
        property = type.GetProperty(prop);
        if (property == null)
        {
            // log error
            break;
        }
        type = property.PropertyType;
    }
    // now property is x
    
