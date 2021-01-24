    {"query":{"type":"Gold Ring"},"sort":{"price":"asc"}}
    
    public class Query
    {
        public string type { get; set; }
    }
    public class Sort
    {
        public string price { get; set; }
    }
    public class RootObject
    {
        public Query query { get; set; }
        public Sort sort { get; set; }
    }
