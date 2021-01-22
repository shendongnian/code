    public static void ThrowIfNull<T>(this T data, string name) where T : class
    {
        if (data == null)
        {
            throw new ArgumentNullException(name);
        }
    }
