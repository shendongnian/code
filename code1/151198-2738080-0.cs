    public static T ChangeTypeTo<T>(this object value)
    {
        if (value == null)
            return null;
        Type underlyingType = typeof (T);
        if (underlyingType == null)
            throw new ArgumentNullException("value");
        if (underlyingType.IsGenericType && underlyingType.GetGenericTypeDefinition()
                                                .Equals(typeof (Nullable<>)))
        {
            var converter = new NullableConverter(underlyingType);
            underlyingType = converter.UnderlyingType;
        }
        // Guid convert
        if (underlyingType == typeof (Guid))
        {
            return new Guid(value.ToString());
        }
        // Check for straight conversion or value.ToString conversion
        var objType = value.GetType();
        // If this is false, lets hope value.ToString can convert otherwise exception
        bool objTypeAssignable2typeT = underlyingType.IsAssignableFrom(objType);
        // Do conversion
        return (T) (objTypeAssignable2typeT ? 
                  Convert.ChangeType(value, underlyingType)
                : Convert.ChangeType(value.ToString(), underlyingType));
    }
