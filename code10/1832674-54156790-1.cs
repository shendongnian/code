    public async Task<IEnumerable<TEntity>> GetAll(int skip = 0, int limit = 100)
    {
        return await ExecuteCmd(
            () => DefaultCollection
                .Find(Filter.Empty)
                .Skip(skip)
                .Limit(limit)
                .ToListAsync()
            );
    }
