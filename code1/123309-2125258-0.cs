    [XmlRoot("NameOfRootElement")]
    public class MyWrapper {
        [XmlElement("NameOfChildElement")]
        public List<MyTest> Items {get;set;}
    }
