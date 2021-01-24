    public class Customer
    {
        public Guid Id { get; set; }
        public string Country { get; set; }
        public LegalPerson Company { get; set; }
        [JsonProperty(PropertyName = "_embedded")]
        public Embedded embedded { get; set; }
    }
    public class Embedded
    {
        public Company company { get; set; }
    }
