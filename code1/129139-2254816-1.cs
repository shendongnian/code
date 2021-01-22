    [XmlRootAttribute("Person", IsNullable= false)]
    public class Person
    {
        public Name Name;
    
        [XmlElement(ElementName = "Gender", DataType = "string")]
        public string gender;
    
        ...
    }
