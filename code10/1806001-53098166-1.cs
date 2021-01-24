    public class ExchangeRate
    {
        [JsonProperty("date")]
        public string Date { get; set; }
        [JsonProperty("rates")]
        public Dictionary<string, decimal> Rate { get; set; }
        [JsonProperty("base")]
        public string Base { get; set; }
        [JsonIgnore]
        public string CurrencyCode
        {
            get
            {
                if (Rate == null)
                {
                    return null;
                }
                string code = Rate.Keys.FirstOrDefault();
                return code;
            }
        }
        [JsonIgnore]
        public decimal CurrencyValue
        {
            get
            {
                if (Rate == null)
                {
                    return default(decimal);
                }
                decimal value = Rate.Values.FirstOrDefault();
                return value;
            }
        }
    }
