    public static Int32? AsInt32(this string s)
    {
        Int32 value;
        if (Int32.TryParse(s, out value))
            return value;
    
        return null;
    }
    public static bool IsInt32(this string s)
    {
        return s.AsInt32().HasValue;
    }
    
    public static Int32 ToInt32(this string s)
    {
        return Int32.Parse(s);
    {
