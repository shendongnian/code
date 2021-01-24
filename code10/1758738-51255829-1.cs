    public class USD
    {
        public double price { get; set; }
        public double volume_24h { get; set; }
        public double market_cap { get; set; }
        public double percent_change_1h { get; set; }
        public double percent_change_24h { get; set; }
        public double percent_change_7d { get; set; }
    }
    
    public class Quotes
    {
        public USD USD { get; set; }
    }
    
    public class Datum
    {
        public int id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public string website_slug { get; set; }
        public int rank { get; set; }
        public double circulating_supply { get; set; }
        public double total_supply { get; set; }
        public double? max_supply { get; set; }
        public Quotes quotes { get; set; }
        public int last_updated { get; set; }
    }
    
    public class Metadata
    {
        public int timestamp { get; set; }
        public int num_cryptocurrencies { get; set; }
        public object error { get; set; }
    }
    
    public class RootObject
    {
        public List<Datum> data { get; set; }
        public Metadata metadata { get; set; }
    }
