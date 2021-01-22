    public static int ParseInt32(this NameValueCollection col, string key)
    {
        return Parse(col, key, int.Parse);
    }
    public static double ParseDouble(this NameValueCollection col, string key)
    {
        return Parse(col, key, double.Parse);
    }
    private static T Parse<T>(NameValueCollection col, string key, Func<string, T> parse)
    {
        string value = col[key];
    
        if (string.IsNullOrEmpty(value))
            return default(T);
    
        return parse(value);
    }
