        public class PortfolioItem
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string Url { get; set; }
            public List<Photo> Photos { get; set; }
        }
        public class Photo
        {
            public string url { get; set; }
            public string thumbnail { get; set; }
            public string description { get; set; }
        }
