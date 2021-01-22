    names.Where(x => x.StartsWith("C")).ForEach(Console.WriteLine);
    // ...
    public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        foreach (T item in source)
        {
            action(item);
        }
    }
