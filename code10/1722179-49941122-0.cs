     public static IQueryable<T> Match<T>(
        IQueryable<T> data,
        string searchTerm,
        IEnumerable<Expression<Func<T, string>>> filterProperties)
    {
        var predicates = filterProperties.Select(selector =>
                selector.Compose(value => 
                    value != null && value.Contains(searchTerm)));
        var filter = predicates.Aggregate(
            PredicateBuilder.False<T>(),
            (aggregate, next) => aggregate.Or(next));
        return data.Where(filter);
    }
