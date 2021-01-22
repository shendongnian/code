    public static bool IsStruct(this Type type)
    {
        return type.IsValueType 
                && !type.IsPrimitive 
                && !type.IsEnum 
                && type != typeof(decimal);
    }
