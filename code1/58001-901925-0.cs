    public class SearchItemResult
    {
        public string Text { get; set; }
        public int ItemId { get; set; }
        public string Path { get; set; }
    }
    
    public IEnumerable<SearchItemResult> SearchItem(int[] itemIds)
    {
        // ...
        IEnumerable<SearchItemResult> results = from ... select new SearchItemResult { ... }
    }
