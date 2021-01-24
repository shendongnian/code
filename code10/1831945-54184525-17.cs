    public class Customer {
        public Guid Id { get; set; }
        public string Country { get; set; }
        [JsonProperty("_embedded.company")]
        public LegalPerson Company { get; set; }
    }
    public class LegalPerson {
        public string Name { get; set; }
        public string IndustrySector { get; set; }
        public string Owner { get; set; }
        [JsonProperty("_embedded.emailAddresses")]
        public ContactInfo[] EmailAddresses { get; set; }
        [JsonProperty("_embedded.phoneNumbers")]
        public ContactInfo[] PhoneNumbers { get; set; }
    }
    
