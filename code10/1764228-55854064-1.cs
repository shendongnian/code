    [XmlRoot(ElementName = "XMLMessage")]
    public class TestClass
    {
        //XmlElement not mandatory, since property names are the same
        [XmlElement(ElementName = "MessageId")]
        public string MessageId { get; set; }
    }
