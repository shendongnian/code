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
                    yield return combine(first, data.Current);
                    first = data.Current;
                }
            }
    }
    int[] b = a
        .Scan((running, current) => running + current)
        .ToArray();
