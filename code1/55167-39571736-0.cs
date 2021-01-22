    public static int GetEnumEntries<T>() where T : struct, IConvertible 
    {
        if (!typeof(T).IsEnum)
            throw new ArgumentException("T must be an enumerated type");
        return Enum.GetNames(typeof(T)).Length;
    }
