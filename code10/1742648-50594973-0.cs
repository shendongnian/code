    [XmlRoot("response")]
    public class Response
    {
        [XmlElement("orderID")]
        public int OrderID { get; set; }
        [XmlElement("internalUse")]
        public bool InternalUse { get; set; }
        [XmlElement("subject")]
        public string Subject { get; set; }
        [XmlElement("message")]
        public string Message { get; set; }
    }
