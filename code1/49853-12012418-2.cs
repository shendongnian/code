    public static IEnumerable<TSource> Prepend<TSource>(this IEnumerable<TSource> source, TSource item)
    {
        if (source == null)
            throw new ArgumentNullException("source");
        yield return item;
        foreach (var element in source)
            yield return element;
    }
    public static IEnumerable<IEnumerable<TSource>> Permutate<TSource>(this IEnumerable<TSource> source)
    {
        if (source == null)
            throw new ArgumentNullException("source");
        var list = source.ToList();
        if (list.Count > 1)
            return from s in list
                    from p in Permutate(list.Take(list.IndexOf(s)).Concat(list.Skip(list.IndexOf(s) + 1)))
                    select p.Prepend(s);
        return new[] { list };
    }
    public static IEnumerable<IEnumerable<TSource>> Combinate<TSource>(this IEnumerable<TSource> source, int k)
    {
        if (source == null)
            throw new ArgumentNullException("source");
        var list = source.ToList();
        if (k > list.Count)
            throw new ArgumentOutOfRangeException("k");
        if (k == 0)
            yield return Enumerable.Empty<TSource>();
        foreach (var l in list)
            foreach (var c in Combinate(list.Skip(list.Count - k - 2), k - 1))
                yield return c.Prepend(l);
    }
