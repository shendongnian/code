    // Can't constrain T to be an enum, unfortunately. This will have to do :)
    public static void ThrowIfNotDefined<T>(T value, string name) where T : struct
    {
        if (!Enum.IsDefined(typeof(T), value))
        {
            throw new ArgumentOutOfRangeException(name);
        }
    }
