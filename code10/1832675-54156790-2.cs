    public Task<IEnumerable<TEntity>> GetAll(int skip = 0, int limit = 100)
    {
        return ExecuteCmd(
            () => DefaultCollection
                .Find(Filter.Empty)
                .Skip(skip)
                .Limit(limit)
                .ToListAsync()
            );
    }
