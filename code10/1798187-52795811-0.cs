    class RootObject
    {
        public string Office { get; set; }
        public List<SearchItem> SearchItemList { get; set; }
    }
    class SearchItem
    {
        public string Column { get; set; }
        public string Operation { get; set; }
        public string Value { get; set; }
    }
