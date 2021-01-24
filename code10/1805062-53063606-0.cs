    public class Address
    {
        [JsonExtensionData]
        public IDictionary<string, JsonToken> extensionData { get; set; }
        [JsonProperty("address")]
        public string Address1 { get; set; }
        [JsonProperty("address2")]
        public string Address2 { get; set; }
        [JsonProperty("town")]
        public string Town { get; set; }
        [JsonProperty("postcode")]
        public string Postcode { get; set; }
    }
