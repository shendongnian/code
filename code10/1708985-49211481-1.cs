    public class Data
    {
        [JsonProperty(PropertyName = "Meta Data")]
        public Metadata Metadata { get; set; }
        [JsonProperty(PropertyName = "Stock Quotes")]
        public IList<StockQuote> StockQuotes { get; set; }
    }
    public class Metadata
    {
        [JsonProperty(PropertyName = "1. Information")]
        public string Information { get; set; }
        [JsonProperty(PropertyName = "2. Notes")]
        public string Notes { get; set; }
        [JsonProperty(PropertyName = "3. Time Zone")]
        public string Timezone { get; set; }
    }
    public class StockQuote
    {
        [JsonProperty(PropertyName = "1. symbol")]
        public string Symbol { get; set; }
        [JsonProperty(PropertyName = "2. price")]
        public string Price { get; set; }
        [JsonProperty(PropertyName = "3. volume")]
        public string Volume { get; set; }
        [JsonProperty(PropertyName = "4. timestamp")]
        public string Timestamp { get; set; }
    }
