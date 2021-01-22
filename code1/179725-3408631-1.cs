    public static IEnumerable<T> Append<T>(this IEnumerable<T> source, T item)
    {
        foreach (T i in source)
            yield return i;
        yield return item;
    }
    public static IEnumerable<T> Prepend<T>(this IEnumerable<T> source, T item)
    {
        yield return item;
        foreach (T i in source)
            yield return i;
    }
