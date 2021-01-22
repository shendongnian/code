    public static string ToSafeString(this object o)
    {
    return o == null ? string.Empty : o.ToString();
    
    }
