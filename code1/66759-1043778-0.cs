    Type type = pi.PropertyType.PropertyType;
    if(type.IsGenericType && type.GetGenericTypeDefinition()
            == typeof(List<>))
    {
        Type itemType = type.GetGenericArguments()[0]; // use this...
    }
