    public class PriceOverview
    {
        public string currency { get; set; }
        public int initial { get; set; }
        public int final { get; set; }
        public int discount_percent { get; set; }
    }
    
    public class Data
    {
        public PriceOverview price_overview { get; set; }
    }
    
    public class RootObject
    {
        public bool success { get; set; }
        public Data data { get; set; }
    }
    
    var result = JsonConvert.DeserializeObject<Dictionary<string, RootObject>>(json);
