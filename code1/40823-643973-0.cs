    public delegate bool Predicate<T>(T item);
    public static IEnumerable<T> Where(IEnumerable<T> source, Predicate pred)
    {
        foreach (T item in source)
        {
            if (pred(item))
                yield return item;
        }
    }
