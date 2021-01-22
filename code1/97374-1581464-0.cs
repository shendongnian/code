    static int[] GetSlots(int slots, int max)
    {
        return new Random().Values(1, max)
                           .Take(slots - 1)
                           .Append(0, max)
                           .OrderBy(i => i)
                           .Pairwise((x, y) => y - x)
                           .ToArray();
    }
    public static IEnumerable<int> Values(this Random random, int minValue, int maxValue)
    {
        while (true)
            yield return random.Next(minValue, maxValue);
    }
    public static IEnumerable<TResult> Pairwise<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TSource, TResult> resultSelector)
    {
        TSource previous = default(TSource);
        using (var it = source.GetEnumerator())
        {
            if (it.MoveNext())
                previous = it.Current;
            while (it.MoveNext())
                yield return resultSelector(previous, previous = it.Current);
        }
    }
    public static IEnumerable<T> Append<T>(this IEnumerable<T> source, params T[] args)
    {
        return source.Concat(args);
    }
