    public class ItemsList
    {
        public IList<Foo> Items { get; set; }
        public int TotalCount { get; set; }
    }
    public ItemsList GetItems(int fooId, int pageIndex, int pageSize, string sortField, string sortDir)
    {
        return new ItemsList { Items = ..., TotalCount = ... };
    }
