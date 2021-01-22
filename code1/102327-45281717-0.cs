    public static IEnumerable<T> IntersectMany<T>(this IEnumerable<IEnumerable<T>> input)
    {
        if (!input.Any())
            return new List<T>();
            
        return input.Aggregate(Enumerable.Intersect);
    }
