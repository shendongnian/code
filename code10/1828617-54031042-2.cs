    public class PaginatedList<TResult> : List<TResult>
    {
        public int PageIndex { get; }
        public int TotalRecords { get; }
        public int TotalPages { get; }
        public PaginatedList(IEnumerable<TResult> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalRecords = count;
            TotalPages = (int)Math.Ceiling(TotalRecords / (double)pageSize);
            AddRange(items);
        }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;
        public static async Task<PaginatedList<TResult>> CreateAsync<TSource>(
            IQueryable<TSource> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .Select(ufc => Mapper.Map<TResult>(ufc))
                .ToListAsync();
            return new PaginatedList<TResult>(items, count, pageIndex, pageSize);
        }
        public static async Task<PaginatedList<TResult>> CreateAsync(
            IQueryable<TResult> source, int pageIndex, int pageSize)
        {
            return await CreateAsync<TResult>(source, pageIndex, pageSize);
        }
    }
