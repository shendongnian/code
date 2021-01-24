    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot(Namespace = "", IsNullable = false)]
    public class Foo
    {
        public string content { get; set; }
        [System.Xml.Serialization.XmlAttribute()]
        public bool isActive { get; set; }
        public Foo()
        {
            isActive = true;
        }
    }
