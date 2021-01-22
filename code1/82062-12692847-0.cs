    public PaginatedList(IQueryable<T> source, int pageIndex, int pageSize)
    {
        var sourceList = source.ToList();
        PageIndex = pageIndex;
        PageSize = pageSize;
        TotalCount = sourceList.Count();
        TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
    
        this.AddRange(sourceList.Skip(PageIndex * PageSize).Take(PageSize));
    }
