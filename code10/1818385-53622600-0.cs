    public static IQueryable<TEntity> Search<TEntity>(
        this IQueryable<TEntity> query,
        Expression<Func<TEntity, string>> fieldExpression,
        string searchValue,
        bool exactSearch = true,
        bool useStartsWithOverContains = false)
    {
        if (string.IsNullOrWhiteSpace(searchValue))
            return query;
        searchValue = searchValue.Trim();
            
        if (exactSearch)
        {
            return query.Where(fieldExpression.Compose(field => field == searchValue));
        }
        else if (useStartsWithOverContains)
        {
            return query.Where(fieldExpression.Compose(field => field.StartsWith(searchValue.ToLower())));
        }
        else
        {
            return query.Where(fieldExpression.Compose(field => field.Contains(searchValue.ToLower())));
        }
    }
