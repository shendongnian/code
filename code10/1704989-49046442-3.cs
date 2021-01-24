    public partial class Event
    {
        [JsonProperty("invoice-id")]
        [JsonConverter(typeof(TolerantNullableLongConverter))]
        public long? InvoiceId { get; set; }
        // Other properties as required
    }
