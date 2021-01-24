    public class Result
    {
        [JsonProperty("allitemscount")]
        public long Allitemscount { get; set; }
    
        public bool UseCustomItems { get; set; }
    }
    
    public class ResultA : Result
    {
        [JsonProperty("customitems")]
        private List<Item> Items { get; set; }
    }
    
    public class ResultB : Result
    {
        [JsonProperty("allitems")]
        private List<Item> Items { get; set; }
    }
    
    public class Item
    {
        [JsonProperty("itemid")]
        public string Itemid { get; set; }
    
        [JsonProperty("itemname")]
        public string Itemname { get; set; }
    }
