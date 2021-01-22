    public static IQueryable<Submission> AddOptionFilter(
        this IQueryable<Submission> query, 
        IEnumerable<IGrouping<int, int>> options)
    {
        var predicate = options.Aggregate(
            PredicateBuilder.False<Submission>(),
            (accumulator, optionIds) => accumulator.Or(ConstructOptionMatchPredicate(optionIds).Expand()));
            query = query.Where(predicate.Expand());            
        return query;
    }
