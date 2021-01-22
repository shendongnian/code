    [Serializable]
    public class Person
    {
        [XmlElement("PersonName")]
        public string Name { get; set; }
    
        [XmlElement("PersonAge")]
        public int Age { get; set; }
    }
