    class Program
    {
        static void Main(string[] args)
        {
            string json = "{\"id\": \"4a17d6fe-a617-4cf8-a850-0fb6bc8576fd\",\"country\": \"DE\",\"_embedded\": {\"company\": {\"name\": \"Apple\",\"industrySector\": \"IT\",\"owner\": \"Klaus Kleber\",\"_embedded\": {\"emailAddresses\": [{\"id\": \"4a17d6fe-a617-4cf8-a850-0fb6bc8576fd\",\"value\": \"test2@consoto.com\",\"type\": \"Business\",\"_links\": {\"self\": {\"href\": \"https://any-host.com/api/v1/customers/1234\"}}}],\"phoneNumbers\": [{\"id\": \"4a17d6fe-a617-4cf8-a850-0fb6bc8576fd\",\"value\": \"01670000000\",\"type\": \"Business\",\"_links\": {\"self\": {\"href\": \"https://any-host.com/api/v1/customers/1234\"}}}],},\"_links\": {\"self\": {\"href\": \"https://any-host.com/api/v1/customers/1234\"},\"phoneNumbers\": {\"href\": \"https://any-host.com/api/v1/customers/1234\"},\"addresses\": {\"href\": \"https://any-host.com/api/v1/customers/1234\"},}},},\"_links\": {\"self\": {\"href\": \"https://any-host.com/api/v1/customers/1234\"},\"legalPerson\": {\"href\": \"https://any-host.com/api/v1/customers/1234\"},\"naturalPerson\": {\"href\": \"https://any-host.com/api/v1/customers/1234\"}}}";
            dynamic results = JsonConvert.DeserializeObject<RootObject>(json);
        }
    }
    public class Self
    {
        public string href { get; set; }
    }
    public class Links
    {
        public Self self { get; set; }
    }
    public class EmailAddress
    {
        public string id { get; set; }
        public string value { get; set; }
        public string type { get; set; }
        public Links _links { get; set; }
    }
    public class Self2
    {
        public string href { get; set; }
    }
    public class Links2
    {
        public Self2 self { get; set; }
    }
    public class PhoneNumber
    {
        public string id { get; set; }
        public string value { get; set; }
        public string type { get; set; }
        public Links2 _links { get; set; }
    }
    public class Embedded2
    {
        public List<EmailAddress> emailAddresses { get; set; }
        public List<PhoneNumber> phoneNumbers { get; set; }
    }
    public class Self3
    {
        public string href { get; set; }
    }
    public class PhoneNumbers
    {
        public string href { get; set; }
    }
    public class Addresses
    {
        public string href { get; set; }
    }
    public class Links3
    {
        public Self3 self { get; set; }
        public PhoneNumbers phoneNumbers { get; set; }
        public Addresses addresses { get; set; }
    }
    public class Company
    {
        public string name { get; set; }
        public string industrySector { get; set; }
        public string owner { get; set; }
        public Embedded2 _embedded { get; set; }
        public Links3 _links { get; set; }
    }
    public class Embedded
    {
        public Company company { get; set; }
    }
    public class Self4
    {
        public string href { get; set; }
    }
    public class LegalPerson
    {
        public string href { get; set; }
    }
    public class NaturalPerson
    {
        public string href { get; set; }
    }
    public class Links4
    {
        public Self4 self { get; set; }
        public LegalPerson legalPerson { get; set; }
        public NaturalPerson naturalPerson { get; set; }
    }
    public class RootObject
    {
        public string id { get; set; }
        public string country { get; set; }
        public Embedded _embedded { get; set; }
        public Links4 _links { get; set; }
    }
