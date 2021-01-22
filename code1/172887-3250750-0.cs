    public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(
        this IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        SortOrder order)
    {
        if(order < SortOrder.Ascending || order > SortOrder.Descending)
        {
            throw new ArgumentOutOfRangeException("order");
        }
        return order == SortOrder.Ascending
            ? source.OrderBy(keySelector)
            : source.OrderByDescending(keySelector);
    }
