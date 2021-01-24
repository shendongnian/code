    class RootObj {
        public Category category { get; set; }
        public List<Detail> details { get; set; }
    }
    
    class Category {
        public string category { get; set; }
        public int pages { get; set; }
    }
    
    class Detail {
        public string name { get; set; }
        public int price { get; set; }
        public string id { get; set; }
        public string img { get; set; }
    }
