    public static bool IsNull<T>(this T obj) where T : class
    {
        return (object)obj == null;
    }
    public static bool IsNull<T>(this T? obj) where T : struct
    {
        return !obj.HasValue;
    }
