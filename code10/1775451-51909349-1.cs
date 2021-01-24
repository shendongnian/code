    public partial class RootData
    {
        [JsonProperty("DataCo")]
        public DataCo[] DataCo { get; set; }
    }
    public partial class DataCo
    {
        [JsonProperty("discount")]
        public long Discount { get; set; }
        [JsonProperty("quote name")]
        public string QuoteName { get; set; }
        [JsonProperty("base price")]
        public long BasePrice { get; set; }
        [JsonProperty("product description")]
        public string ProductDescription { get; set; }
        [JsonProperty("plant")]
        public string Plant { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("final price")]
        public long FinalPrice { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("quote id")]
        public string QuoteId { get; set; }
        [JsonProperty("freight")]
        public string Freight { get; set; }
        [JsonProperty("billing price")]
        public long BillingPrice { get; set; }
        [JsonProperty("quantity")]
        public long Quantity { get; set; }
        [JsonProperty("proposed price")]
        public long ProposedPrice { get; set; }
        [JsonProperty("user")]
        public string User { get; set; }
        [JsonProperty("product id")]
        public long ProductId { get; set; }
    }
