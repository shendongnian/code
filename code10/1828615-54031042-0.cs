    public static async Task<PaginatedList<TResult>> CreateAsync<TSource>(
        IQueryable<TSource> source, int pageIndex, int pageSize)
    {
        Ensure.It.IsGreaterThan(0, pageIndex);
        Ensure.It.IsGreaterThan(0, pageSize);
        var count = await source.CountAsync();
        var items = await source.Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .Select(ufc => Mapper.Map<TResult>(ufc))
            .ToListAsync();
        return new PaginatedList<TResult>(items, count, pageIndex, pageSize);
    }
