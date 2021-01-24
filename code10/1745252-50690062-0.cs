    public class RequiredClass
    {
        public IList<Datum> data { get; set; }
        public Meta meta { get; set; }
    }
    public class Datum
    {
        public string Val1 { get; set; }
        public string Val2 { get; set; }
        public string Val3 { get; set; }
        public IList<Link> links { get; set; }
    }
    public class Link
    {
        public string rel { get; set; }
        public string uri { get; set; }
    }
    public class Pagination
    {
        public int total { get; set; }
        public int count { get; set; }
        public int per_page { get; set; }
        public int current_page { get; set; }
        public int total_pages { get; set; }
        public IList<object> links { get; set; }
    }
    public class Meta
    {
        public Pagination pagination { get; set; }
    }
