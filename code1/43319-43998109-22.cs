    public static bool CheckObjectImpl(object o)
    {
        return o != null;
    }
    
    public static bool CheckNullableImpl<T>(T? o) where T: struct
    {
        return o.HasValue;
    }
