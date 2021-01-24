    public class Result // main object
    {
        [JsonProperty("allitemscount")]
        public long Allitemscount { get; set; }
    
        public bool UseCustomItems { get; set; }
    }
    
    public class ResultA : Result // CustomItems Model
    {
        [JsonProperty("customitems")]
        private List<Item> Items { get; set; }
    }
    
    public class ResultB : Result // AllItems Model
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
