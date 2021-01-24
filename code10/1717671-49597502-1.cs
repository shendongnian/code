    public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
    {
        var query = Context.Set<T>()
            .Include(Context.GetIncludePaths(typeof(T));
        if (predicate != null)
            query = query.Where(predicate);
        return await query.ToListAsync();
    }
