    public static IEnumerable<TSource> ExceptAll<TSource>(
        this IEnumerable<TSource> first,
        IEnumerable<TSource> second)
    {
        // Do not call reuse the overload method because that is a slower imlementation
        if (first == null) { throw new ArgumentNullException("first"); }
        if (second == null) { throw new ArgumentNullException("second"); }
        var secondList = second.ToList();
        return first.Where(s => !secondList.Remove(s));
    }
    public static IEnumerable<TSource> ExceptAll<TSource>(
        this IEnumerable<TSource> first,
        IEnumerable<TSource> second,
        IEqualityComparer<TSource> comparer)
    {
        if (first == null) { throw new ArgumentNullException("first"); }
        if (second == null) { throw new ArgumentNullException("second"); }
        var comparerUsed = comparer ?? EqualityComparer<TSource>.Default;
        var secondList = second.ToList();
        foreach (var item in first)
        {
            if (secondList.Contains(item, comparerUsed))
            {
                secondList.Remove(item);
            }
            else
            {
                yield return item;
            }
        }
    }
