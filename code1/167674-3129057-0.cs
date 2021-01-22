    [XmlRoot("myOuterElement")]
    public class MyOuterMessage {
        [XmlElement("item")]
        public List<TestObject> Items {get;set;}
    }
