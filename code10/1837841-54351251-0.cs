    public class SearchList {
        public Position coord { get; set; }
        public int resultCount { get; set; }
        public Result[] weather { get; set; }
    }
    public class Position {  
        public double lon { get; set; }
        public double lat { get; set; }
    }
