    using System.Xml.Serialization;
    
    ...
    
    [XmlRoot("someclass")]
    public class SomeClass
    {
        [XmlAttribute("p01")]
        public int MyProperty01
        {
            get { ... }
        }
    
        [XmlArray("sometypes")]
        public SomeType[] MyProperty02
        {
            get { ... }
        }
    
        [XmlText]
        public int MyProperty03
        {
            get { ... }
        }
        public SomeClass()
        {
        }
    }
