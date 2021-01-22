    public class Name
    {
        [XmlElement(ElementName = "First")]
        public string firstName;
        [XmlElement(ElementName = "Middle", IsNullable = true)]
        public string middleName;
        [XmlElement(ElementName = "Last")]
        public string lastName;
        [XmlElement(ElementName = "Madian", IsNullable = true)]
        public string madianName;
    }
