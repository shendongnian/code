    public static IEnumerable<T> TakeRandom<T>(this IEnumerable<T> source, int count)
    {
        var list = source as IList<T> ?? source.ToList();
        return ShuffleInternal(list, Math.Min(count, list.Count)).Take(count);
    }
    private static IEnumerable<T> ShuffleInternal<T>(IList<T> list, int count)
    {
        for (var n = 0; n < count; n++)
        {
            var k = ThreadSafeRandom.Next(n, list.Count);
            var temp = list[n];
            list[n] = list[k];
            list[k] = temp;
        }
        return list;
    }
