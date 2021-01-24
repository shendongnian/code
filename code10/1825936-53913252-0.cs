    public class RootObject
        {
            public Bookshelf bookshelf { get; set; }
        }
    public class Bookshelf
    {
        public long shelfId { get; set; }
        public string shelfName { get; set; }
        public object description { get; set; }
        public long[] bookOrder { get; set; }
        public string createrType { get; set; }
    }
