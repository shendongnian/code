    public IQueryable<T> OldMethod(params Expression<Func<T, object>>[] includeProperties)
    {
        var queryable = set.AsQueryable();
        return includeProperties.Aggregate(queryable, (current, includeProperty) => 
            current.Include(includeProperty.ToPropertyPath()));
    }
