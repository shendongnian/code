    public class EmailConfiguration
    {
        public string DataBoxID { get; set; }
        public DefaultSendToAddressCollectionClass DefaultSendToAddressCollection { get; set; }
    }
    
    public class DefaultSendToAddressCollectionClass
    {
        [XmlElement]
        public string[] EmailAddress { get; set; }
    }
