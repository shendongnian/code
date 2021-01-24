    public class Payment
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Card Card { get; set; }
    
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Debit Debit { get; set; }
    
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Check Check { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Cash Cash { get; set; }
    }
