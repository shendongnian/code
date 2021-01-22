    readonly T[] values = (T[])Enum.GetValues(typeof(T));
    public static IEnumerable<T> Values //a property makes sense
    {
        get { return values; }
    }
