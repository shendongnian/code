    public static IEnumerable<TResult> Scan<T, TResult>(
        this IEnumerable<T> source, 
        Func<T, T, TResult> combine)
    {
        using (IEnumerator<T> data = source.GetEnumerator())
            if (data.MoveNext())
            {
                T first = data.Current;
                yield return first;
                while (data.MoveNext())
                {
                    first = combine(first, data.Current);
                    yield return first;
                }
            }
    }
    int[] b = a
        .Scan((running, current) => running + current)
        .ToArray();
