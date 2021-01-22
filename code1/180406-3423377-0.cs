    public class SomeObject
    {
        [XmlElement("InternalId")]
        [XmlElement("id")]
        public Guid InternalId { get; set; }
        [XmlElement("Address")]
        [XmlElement("ad")]
        public string Address { get; set; }
    }
