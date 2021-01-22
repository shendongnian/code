    public class SerializableClass
    {
        [XmlElement]
        public int ID { get; set; }
        [XmlElement]
        public string Name { get; set; }
        [XmlIgnore]
        public IMyInterface Intf { get; set; }
    }
