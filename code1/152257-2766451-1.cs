    public class ItemsList
    {
        public IList<Foo> Items { get; set; }
        public int TotalCount { get; set; }
        public string SortField { get; set; }
        public string SortDirection { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
