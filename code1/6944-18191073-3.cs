    static readonly T[] values = (T[])Enum.GetValues(typeof(T));
    public static IEnumerable<T> Values
    {
        get { return values; }
    }
