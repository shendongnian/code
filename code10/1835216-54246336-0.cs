    public abstract PagedListViewModel<T>
     {
        int NumberOfPagesAvailable { get; set; }
        int CurrentPageIndex { get; set; }
        int PageSize { get; set; }
        List<T> ListOfItems { get; set; }
     }
