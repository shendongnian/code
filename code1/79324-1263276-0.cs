    Type interfaceType = prop.PropertyType.GetInterface("IComparable");
    if (interfaceType == null && prop.PropertyType.IsValueType)
    {
        Type underlyingType = Nullable.GetUnderlyingType(prop.PropertyType);
        if (underlyingType != null)
            interfaceType = underlyingType.GetInterface("IComparable");
    }
    if (interfaceType != null)
       // rest of sample
