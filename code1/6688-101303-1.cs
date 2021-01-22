    public static void ForEach<T>(this IEnumerable<T> col, Action<T> action)
    {
        if (action == null)
        {
            throw new ArgumentNullException("action");
        }
        foreach (var item in col)
        {
            action(item);
        }
    }
