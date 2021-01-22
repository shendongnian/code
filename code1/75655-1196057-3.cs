    public static void ThrowIfNull<T>(this T value, string name) where T : class
    {
        if (value == null)
        {
            throw new ArgumentNullException(name);
        }
    }
