    [XmlRoot(ElementName = "PersonList")]
    public class PersonList
    {
        [XmlElement(ElementName = "Person")]
        public List<Person> Person { get; set; }
    }
    [XmlRoot(ElementName = "Person")]
    public class Person
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "tag")]
        public string Tag { get; set; }
    }
