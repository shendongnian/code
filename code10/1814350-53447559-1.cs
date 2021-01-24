    public partial class Welcome
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("stock_exchange_short")]
        public string StockExchangeShort { get; set; }
        [JsonProperty("timezone_name")]
        public string TimezoneName { get; set; }
        [JsonProperty("intraday")]
        public Dictionary<string, Intraday> Intraday { get; set; }
    }
    public partial class Intraday
    {
        [JsonProperty("open")]
        public string Open { get; set; }
        [JsonProperty("close")]
        public string Close { get; set; }
        [JsonProperty("high")]
        public string High { get; set; }
        [JsonProperty("low")]
        public string Low { get; set; }
        [JsonProperty("volume")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Volume { get; set; }
    }
