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
    
    var results = JsonConvert.DeserializeObject<Dictionary<string, RootObject>>(json);
    foreach (var result in results)
    {
       Console.WriteLine(result.Key);
       Console.WriteLine(result.Value.data.price_overview.currency);
       Console.WriteLine(result.Value.data.price_overview.initial);
       Console.WriteLine(result.Value.data.price_overview.final);
       Console.WriteLine(result.Value.data.price_overview.discount_percent);
       
    }
