    private IQueryable<T> ApplySorting<T,U>(IQueryable<T> query, Expression<Func<T, U>> predicate, SortOrder order)
    {
        var ordered = query as IOrderedQueryable<T>;
        if (order == SortOrder.Ascending)
        {
            if (ordered != null)
                return ordered.ThenBy(predicate);
            return query.OrderBy(predicate);
        }
        else
        {
            if (ordered != null)
                return ordered.ThenByDescending(predicate);
            return query.OrderByDescending(predicate);
        }
    }
