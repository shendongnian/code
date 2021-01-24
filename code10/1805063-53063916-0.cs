    public class Address
    {
        [JsonProperty("flat_number", NullValueHandling = NullValueHandling.Ignore)]
        public string FlatNumber { get; set; }
        [JsonProperty("house_number", NullValueHandling = NullValueHandling.Ignore)]
        public string HouseNumber { get; set; }
        [JsonProperty("address")]
        public string Address1 { get; set; }
        [JsonProperty("address2")]
        public string Address2 { get; set; }
        [JsonProperty("town")]
        public string Town { get; set; }
        [JsonProperty("postcode")]
        public string Postcode { get; set; }
    }
