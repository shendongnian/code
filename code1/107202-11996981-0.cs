    public static IEnumerable<T> SkipLast<T>(this IEnumerable<T> source, int count)
    {
        var enumerator = source.GetEnumerator();
        var cache = new Queue<T>(count + 1);
        while (true)
        {
            if (!enumerator.MoveNext())
                break;
            cache.Enqueue(enumerator.Current);
            if (cache.Count > count)
                yield return cache.Dequeue();
        }
    }
