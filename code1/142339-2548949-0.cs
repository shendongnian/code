    [XmlRoot("sender")]
    public sealed class FaxSender
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("organization")]
        public string Organization { get; set; }
        [XmlElement("phone_number")]
        public string PhoneNumber { get; set; }
        [XmlElement("fax_number")]
        public string FaxNumber { get; set; }
        [XmlElement("email_address")]
        public string EmailAddress { get; set; }
    
        // Remaining code omitted
    }
