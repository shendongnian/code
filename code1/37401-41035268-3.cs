    [XmlType("idle")]
    public class IdleMessage : XmlMessage
    {
        [XmlElement(ElementName = "id", IsNullable = true)]
        public string MessageId
        {
            get;
            set;
        }
    }
