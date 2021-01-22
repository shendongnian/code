    public static T FirstOr<T>(this IEnumerable<T> source, T alternate)
    {
        return source.DefaultIfEmpty(alternate)
                     .First();
    }
    public static T FirstOr<T>(this IEnumerable<T> source, Func<T, bool> predicate, T alternate)
    {
        return source.Where(predicate)
                     .FirstOr(alternate);
    }
