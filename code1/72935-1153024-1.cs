    [XmlRoot("exception"), XmLType("exception")]
    public class SerializableException {
        [XmlElement("message")]
        public string Message {get;set;}
        [XmlElement("innerException")]
        public SerializableException InnerException {get;set;}
    }
