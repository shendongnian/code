    public class ExchangeRate
    {
        [JsonProperty("date")]
        public string Date { get; set; }
        [JsonProperty("rates")]
        public Dictionary<string, decimal> Rate { get; set; }
        [JsonProperty("base")]
        public string Base { get; set; }
    }
