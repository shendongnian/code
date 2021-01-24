    public static async Task<PaginatedList<TResult>> CreateAsync(
        IQueryable<TResult> source, int pageIndex, int pageSize)
    {
        return await CreateAsync<TResult>(source, pageIndex, pageSize);
    }
