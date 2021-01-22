    public static bool TryCast<T>(this object value, out T result)
    {
        var type = typeof (T);
    
        // If the type is nullable and the result should be null, set a null value.
        if (type.IsNullable() && (value == null || value == DBNull.Value))
        {
            result = default(T);
            return true;
        }
    
        // Convert.ChangeType fails on Nullable<T> types.  We want to try to cast to the underlying type anyway.
        var underlyingType = Nullable.GetUnderlyingType(type) ?? type;
    
        try
        {
            // Just one edge case you might want to handle.
            if (underlyingType == typeof(Guid))
            {
                if (value is string)
                {
                    value = new Guid(value as string);
                }
                if (value is byte[])
                {
                    value = new Guid(value as byte[]);
                }
    
                result = (T)Convert.ChangeType(value, underlyingType);
                return true;
            }
    
            result = (T)Convert.ChangeType(value, underlyingType);
            return true;
        }
        catch (Exception ex)
        {
            result = default(T);
            return false;
        }
    }
