    class Program
    {
        static void Main(string[] args)
        {
            string json = "{\"id\": \"4a17d6fe-a617-4cf8-a850-0fb6bc8576fd\",\"country\": \"DE\",\"_embedded\": {\"company\": {\"name\": \"Apple\",\"industrySector\": \"IT\",\"owner\": \"Klaus Kleber\",\"_embedded\": {\"emailAddresses\": [{\"id\": \"4a17d6fe-a617-4cf8-a850-0fb6bc8576fd\",\"value\": \"test2@consoto.com\",\"type\": \"Business\",\"_links\": {\"self\": {\"href\": \"https://any-host.com/api/v1/customers/1234\"}}}],\"phoneNumbers\": [{\"id\": \"4a17d6fe-a617-4cf8-a850-0fb6bc8576fd\",\"value\": \"01670000000\",\"type\": \"Business\",\"_links\": {\"self\": {\"href\": \"https://any-host.com/api/v1/customers/1234\"}}}],},\"_links\": {\"self\": {\"href\": \"https://any-host.com/api/v1/customers/1234\"},\"phoneNumbers\": {\"href\": \"https://any-host.com/api/v1/customers/1234\"},\"addresses\": {\"href\": \"https://any-host.com/api/v1/customers/1234\"},}},},\"_links\": {\"self\": {\"href\": \"https://any-host.com/api/v1/customers/1234\"},\"legalPerson\": {\"href\": \"https://any-host.com/api/v1/customers/1234\"},\"naturalPerson\": {\"href\": \"https://any-host.com/api/v1/customers/1234\"}}}";
            dynamic results = JsonConvert.DeserializeObject<Customer>(json);
        }
    }
    public class ContactInfo
    {
        public Guid id { get; set; }
        public string value { get; set; }
        public string type { get; set; }
        public Href _links { get; set; }
    }
    public class EmbeddedContactInfo
    {
        public List<ContactInfo> emailAddresses { get; set; }
        public List<ContactInfo> phoneNumbers { get; set; }
    }
    public class Company
    {
        public string name { get; set; }
        public string industrySector { get; set; }
        public string owner { get; set; }
        public EmbeddedContactInfo _embedded { get; set; }
        public EmbeddedLinks _links { get; set; }
    }
    public class Embedded
    {
        public Company company { get; set; }
    }
    public class Href
    {
        public string href { get; set; }
    }
    
    public class EmbeddedLinks
    {
        public Href self { get; set; }
        public Href phoneNumbers { get; set; }
        public Href addresses { get; set; }
    }
    public class Links
    {
        public Href self { get; set; }
        public Href legalPerson { get; set; }
        public Href naturalPerson { get; set; }
    }
    public class Customer
    {
        public Guid id { get; set; }
        public string country { get; set; }
        public Embedded _embedded { get; set; }
        public Links _links { get; set; }
    }
