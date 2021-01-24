     public abstract PagedListViewModel
     {
        int NumberOfPagesAvailable { get; set; }
        int CurrentPageIndex { get; set; }
        int PageSize { get; set; }
     }
