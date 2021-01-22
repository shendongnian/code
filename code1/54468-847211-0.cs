    public static bool IsNullOrEmpty(this string value)
    {
        return string.IsNullOrEmpty(value);
    }
    public static void ThrowIfNull<T>(this T obj, string parameterName)
            where T : class
    {
        if(obj == null) throw new ArgumentNullException(parameterName);
    }
