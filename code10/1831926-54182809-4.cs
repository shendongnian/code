    [JsonConverter(typeof(JsonPathConverter))]
    public class Customer
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("_embedded.company")]
        public LegalPerson Company { get; set; }
    }
    
    [JsonConverter(typeof(JsonPathConverter))]
    public class LegalPerson
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("industrySector")]
        public string IndustrySector { get; set; }
        [JsonProperty("owner")]
        public string Owner { get; set; }
        [JsonProperty("_embedded.emailAddresses")]
        public ContactInfo[] EmailAddresses { get; set; }
        [JsonProperty("_embedded.phoneNumbers")]
        public ContactInfo[] PhoneNumbers { get; set; }
    }
    public class ContactInfo
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("value")]
        public string Type { get; set; }
        [JsonProperty("type")]
        public string Value { get; set; }
    }
