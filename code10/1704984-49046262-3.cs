    class Event {
        [JsonProperty("invoice-id")]        
        [JsonConverter(typeof(NullableLongFixupConverter))]
        public long? InvoiceId { get; set; }
    }
