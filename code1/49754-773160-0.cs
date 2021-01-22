    public delegate bool TryParseDelegate<T>(string data, out T output);
    
    public static T? ToNullablePrimitive<T>(this string data, 
        TryParseDelegate<T> func) where T:struct
    {
        string.IsNullOrEmpty(data) return null;
        T output;
    
        if (func(data, out output))
        {
            return (T?)output;
        }
    
        return null;
    }
