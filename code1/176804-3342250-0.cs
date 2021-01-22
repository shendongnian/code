    public IQueryable<TResult> GetHotelsGroupBy<TKey, TResult>(
        Expression<Func<T_Hotels, bool>> pWhere,
        Expression<Func<T_Hotels, TKey>> pGroupBy, 
        Expression<Func<IGrouping<TKey, T_Hotels>, TResult>> pSelect
    )
    {
        return c.CreateQuery<T_Hotels>("T_Hotels")
                .Where(pWhere)
                .GroupBy(pGroupBy)
                .Select(pSelect);
    }
