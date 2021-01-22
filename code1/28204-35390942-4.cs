    public class PageEntity
    {
        public int Page { get; set; }
        public string Class { get; set; }
    }
    public class Pagination
    {
        public List<PageEntity> Pages { get; set; }
        public int Next { get; set; }
        public int Previous { get; set; }
        public string NextClass { get; set; }
        public string PreviousClass { get; set; }
        public bool Display { get; set; }
        public string Query { get; set; }
    }
