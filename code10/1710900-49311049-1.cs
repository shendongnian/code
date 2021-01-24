    public static IEnumerable<IGrouping<int, TResult>> GroupByRuns<TElement, TKey, TResult>(this IEnumerable<TElement> src, Func<TElement, TKey> key, Func<TElement, TResult> result, IEqualityComparer<TKey> cmp = null) {
        cmp = cmp ?? EqualityComparer<TKey>.Default;
        return src.ScanPair(0,
                            (kvp, cur) => cmp.Equals(key(kvp.Value), key(cur)) ? kvp.Key : kvp.Key + 1)
                  .GroupBy(kvp => kvp.Key, kvp => result(kvp.Value));
    }
    public static IEnumerable<IGrouping<int, TElement>> GroupByRuns<TElement, TKey>(this IEnumerable<TElement> src, Func<TElement, TKey> key) => src.GroupByRuns(key, e => e);
    public static IEnumerable<IGrouping<int, TElement>> GroupByRuns<TElement>(this IEnumerable<TElement> src) => src.GroupByRuns(e => e, e => e);
    public static IEnumerable<IEnumerable<TResult>> Runs<TElement, TKey, TResult>(this IEnumerable<TElement> src, Func<TElement, TKey> key, Func<TElement, TResult> result, IEqualityComparer<TKey> cmp = null) =>
        src.GroupByRuns(key, result).Select(g => g.Select(s => s));
    public static IEnumerable<IEnumerable<TElement>> Runs<TElement, TKey>(this IEnumerable<TElement> src, Func<TElement, TKey> key) => src.Runs(key, e => e);
    public static IEnumerable<IEnumerable<TElement>> Runs<TElement>(this IEnumerable<TElement> src) => src.Runs(e => e, e => e);
