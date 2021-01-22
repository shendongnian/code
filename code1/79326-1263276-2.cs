    Type interfaceType = prop.PropertyType.GetInterface("IComparable");
    // Interface not found on the property's type. Maybe the property was nullable?
    // For that to happen, it must be value type.
    if (interfaceType == null && prop.PropertyType.IsValueType)
    {
        Type underlyingType = Nullable.GetUnderlyingType(prop.PropertyType);
        // Nullable.GetUnderlyingType only returns a non-null value if the
        // supplied type was indeed a nullable type.
        if (underlyingType != null)
            interfaceType = underlyingType.GetInterface("IComparable");
    }
    if (interfaceType != null)
       // rest of sample
