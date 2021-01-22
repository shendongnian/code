    [XmlRoot]
    public class EmailConfiguration
    {
        [XmlElement]
        public string DataBoxID { get; set; }
    
        [XmlElement]
        public DefaultSendToAddressCollectionClass DefaultSendToAddressCollection { get; set; }
    }
    public class DefaultSendToAddressCollectionClass
    {
        [XmlElement]
        public string[] EmailAddress { get; set; }
    }
