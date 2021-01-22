    public static bool IsEmpty<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        if (source == null) throw new ArgumentNullException();
        if (IsCollectionAndEmpty(source)) return true;
        return !source.Any(predicate);
    }
    public static bool IsEmpty<TSource>(this IEnumerable<TSource> source)
    {
        if (source == null) throw new ArgumentNullException();
        if (IsCollectionAndEmpty(source)) return true;
        return !source.Any();
    }
    private static bool IsCollectionAndEmpty<TSource>(IEnumerable<TSource> source)
    {
        var genericCollection = source as ICollection<TSource>;
        if (genericCollection != null) return genericCollection.Count == 0;
        var nonGenericCollection = source as ICollection;
        if (nonGenericCollection != null) return nonGenericCollection.Count == 0;
        return false;
    }
