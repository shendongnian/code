    public static T? TryParse<T>(string value, TryParseHandler<T> handler) where T : struct
    {
        if (String.IsNullOrEmpty(value))
            return null;
        T result;
        if (handler(value, out result))
            return result;
        Trace.TraceWarning("Invalid value '{0}'", value);
        return null;
    }
    
    public delegate bool TryParseHandler<T>(string value, out T result);
