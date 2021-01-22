    [XmlRoot("Foo")]
    public class Foo
    {
        [XmlElement("name")]
        public string name;
    }
    [XmlRoot("FooContainer")]
    public class FooContainer
    {
        [XmlElement("container")]
        public List<SerializableList<Foo>> lst { get; set; }
    }
    [XmlRoot("list")]
    public class SerializableList<T>
    {
        [XmlElement("items")]
        public List<T> lst { get; set; }
    }
