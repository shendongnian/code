    if (pi.PropertyType.IsGeneric &&
        pi.PropertyType.GetGenericTypeDefinition() == typeof(EntityCollection<>))
    {
        // This is now safe
        var elementType = pi.PropertyType.GetGenericArguments()[0];
        // ...
    }
