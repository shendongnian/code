    internal static T NullGuard<T>(this T argument, string name)
        where T : class
    {
        if (argument == null)
        {
            throw new ArgumentNullException(name);
        }
    }
