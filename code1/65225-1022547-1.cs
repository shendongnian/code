    [XmlRoot("Object")
    public class SerializableObjectForPersistance
    {
        [XmlElement(Order = 1)]
        public bool Property1 { get; set; }
        [XmlElement(Order = 2, IsNullable=true)]
        public bool Property2 { get; set; }
        [XmlElement(Order = 3)]
        public bool Property3 { get; set; }
    }
