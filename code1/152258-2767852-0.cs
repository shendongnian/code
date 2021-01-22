    public interface IPagedList
    {
        int TotalCount { get; set; }
        int PageIndex  { get; set; }
        int PageSize { get; set; }
        bool IsPreviousPage { get; }
        bool IsNextPage { get; }   
    }
