    public static IEnumerable<T> Concat(this IEnumerable<T> source1,
        IEnumerable<T> source2)
    {
        if (source1 == null)
        {
            throw new ArgumentNullException("source1");
        }
        if (source2 == null)
        {
            throw new ArgumentNullException("source1");
        }
        return ConcatImpl(source1, source2);
    }
    private static IEnumerable<T> ConcatImpl(this IEnumerable<T> source1,
        IEnumerable<T> source2)
    {
        foreach (T item in source1)
        {
            yield return item;
        }
        foreach (T item in source2)
        {
            yield return item;
        }
    }
