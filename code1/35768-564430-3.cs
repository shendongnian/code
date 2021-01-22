    public static void IgnorantForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        foreach (var item in source)
        {
            try
            {
                action(item);
            }
            catch { }
        }
    }
