    public static DateTime ToDateTime(bool value)
    {
        return ((IConvertible) value).ToDateTime(null);
    }
 
