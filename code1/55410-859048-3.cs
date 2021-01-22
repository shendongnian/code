    public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        if (action == null)
        {
            throw new ArgumentNullException("action", "Parameter cannot be null.");
        }
        foreach (T item in source)
        {
            action(item);
        }
    }
