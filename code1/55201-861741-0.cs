    public static T GetOrDefault<T>(this IInfosContainer container, string key, T defaultValue)
    {
        //I just read p273 of C# in Depth, +1 Jon Skeet :)
        if (container == null) throw new ArgumentNullException("container");
        if (container.Exist(key))
        {
            if (container.GetType(key) != typeof(T))
                throw new ArgumentOutOfRangeException("key",
                    "Key exists, but not same type as defaultValue parameter");
            else
                return (T)container.GetAsObject(key);
        }
        else
            return defaultValue;
    }
