    PropertyInfo p = // ... get property info
    Type t = p.GetType();
    if (t.IsGenericType && 
        t.GetGenericTypeDefinition == typeof(EnumValue<>))
    {
        Type e = t.GetGenericArguments()[0]; // get first (and only) type arg
        // e is the enum type...
