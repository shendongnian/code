        class Program
        {
            static void Main(string[] args)
            {
                string json = "{\"id\": \"4a17d6fe-a617-4cf8-a850-0fb6bc8576fd\",\"country\": \"DE\",\"_embedded\": {\"company\": {\"name\": \"Apple\",\"industrySector\": \"IT\",\"owner\": \"Klaus Kleber\",\"_embedded\": {\"emailAddresses\": [{\"id\": \"4a17d6fe-a617-4cf8-a850-0fb6bc8576fd\",\"value\": \"test2@consoto.com\",\"type\": \"Business\",\"_links\": {\"self\": {\"href\": \"https://any-host.com/api/v1/customers/1234\"}}}],\"phoneNumbers\": [{\"id\": \"4a17d6fe-a617-4cf8-a850-0fb6bc8576fd\",\"value\": \"01670000000\",\"type\": \"Business\",\"_links\": {\"self\": {\"href\": \"https://any-host.com/api/v1/customers/1234\"}}}],},\"_links\": {\"self\": {\"href\": \"https://any-host.com/api/v1/customers/1234\"},\"phoneNumbers\": {\"href\": \"https://any-host.com/api/v1/customers/1234\"},\"addresses\": {\"href\": \"https://any-host.com/api/v1/customers/1234\"},}},},\"_links\": {\"self\": {\"href\": \"https://any-host.com/api/v1/customers/1234\"},\"legalPerson\": {\"href\": \"https://any-host.com/api/v1/customers/1234\"},\"naturalPerson\": {\"href\": \"https://any-host.com/api/v1/customers/1234\"}}}";
    
                CustomerJson results = JsonConvert.DeserializeObject<CustomerJson>(json);
                Customer customer = new Customer()
                {
                    Id = results.id,
                    Country = results.country,
                    Company = new LegalPerson()
                    {
                        EmailAddresses = results._embedded.company._embedded.emailAddresses,
                        PhoneNumbers = results._embedded.company._embedded.phoneNumbers,
                        IndustrySector = results._embedded.company.industrySector,
                        Name = results._embedded.company.name,
                        Owner = results._embedded.company.owner
                    }
                };
    
            }
    
        }
        
        public class EmbeddedContactInfoJson
        {
            public ContactInfo[] emailAddresses { get; set; }
            public ContactInfo[] phoneNumbers { get; set; }
        }
        public class CompanyJson
        {
            public string name { get; set; }
            public string industrySector { get; set; }
            public string owner { get; set; }
            public EmbeddedContactInfoJson _embedded { get; set; }
            public EmbeddedLinksJson _links { get; set; }
        }
    
        public class EmbeddedJson
        {
            public CompanyJson company { get; set; }
        }
        public class HrefJson
        {
            public string href { get; set; }
        }
    
        public class EmbeddedLinksJson
        {
            public HrefJson self { get; set; }
            public HrefJson phoneNumbers { get; set; }
            public HrefJson addresses { get; set; }
        }
        public class LinksJson
        {
            public HrefJson self { get; set; }
            public HrefJson legalPerson { get; set; }
            public HrefJson naturalPerson { get; set; }
        }
        public class CustomerJson
        {
            public Guid id { get; set; }
            public string country { get; set; }
            public EmbeddedJson _embedded { get; set; }
            public LinksJson _links { get; set; }
        }
    
        public class Customer
        {
            public Guid Id { get; set; }
            public string Country { get; set; }
            public LegalPerson Company { get; set; }
        }
        public class LegalPerson
        {
            public string Name { get; set; }
            public string IndustrySector { get; set; }
            public string Owner { get; set; }
            public ContactInfo[] EmailAddresses { get; set; }
            public ContactInfo[] PhoneNumbers { get; set; }
        }
        public class ContactInfo
        {
            public Guid Id { get; set; }
            public string Type { get; set; }
            public string Value { get; set; }
        }
