    public static IEnumerable<T> IntersectNonEmpty<T>(this IEnumerable<IEnumerable<T>> lists)
    {
        var nonEmptyLists = lists.Where(l => l.Any());
        return nonEmptyLists.Aggregate((l1, l2) => l1.Intersect(l2));
    }
