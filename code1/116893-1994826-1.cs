    foreach ( var property in properties )
    {
        // extract some information about each property:
        string propertyName = property.Name;
        Type propertyType = property.PropertyType;
        bool propertyReadOnly = !property.CanWrite;
        // create input controls based on this information:
        // ...
    }
