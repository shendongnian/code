        Type underlyingType = Type.GetType(someType);
        if (underlyingType.IsGenericType && underlyingType.GetGenericTypeDefinition().Equals(typeof (Nullable<>)))
        {
            var converter = new NullableConverter(underlyingType);
            underlyingType = converter.UnderlyingType;
        }
        // Try changing to Guid  
        if (underlyingType == typeof (Guid))
        {
            return new Guid(value.ToString());
        }
        return Convert.ChangeType(value, underlyingType);
