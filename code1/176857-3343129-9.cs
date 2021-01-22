    [Serializable]
    public class Person
    {
        [XmlElement("PersonName")]
        public string Name { get; set; }
    
        [XmlElement("PersonAge")]
        public int Age { get; set; }
        [XmlArrayItem("Child")]
        public List<string> Children { get; set; }
    }
