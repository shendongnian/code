    internal static void ThrowIfNull<T>(this T argument, string name)
        where T : class
    {
        if (argument == null)
        {
            throw new ArgumentNullException(name);
        }
    }
