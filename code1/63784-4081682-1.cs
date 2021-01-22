    public static IEnumerable<T> Intercalate<T>(this IEnumerable<IEnumerable<T>> source,
                                                IEnumerable<T> separator) {
        if (source == null) throw new ArgumentNullException("source");
        if (separator == null) throw new ArgumentNullException("separator");
        return source.Intersperse(separator)
            .Aggregate(Enumerable.Empty<T>(), Enumerable.Concat);
    }
