    [XmlRoot(ElementName = "mibscalar")]
    public class Mibscalar
    {
        [XmlAttribute(AttributeName = "link")]
        public string Link { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlElement("bit", typeof(Bit))]
        [XmlElement("index", typeof(Index))]
        public List<DataItemBase> Items { get; set; }
    }
    public class Data
    {
        [XmlAttribute(AttributeName = "index")]
        public string Index { get; set; }
        [XmlAttribute(AttributeName = "counter")]
        public string Counter { get; set; }
        [XmlElement("bit", typeof(Bit))]
        [XmlElement("index", typeof(Index))]
        public List<DataItemBase> Items { get; set; }
    }
    public abstract class DataItemBase
    {
    }
    public class Index : DataItemBase
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "data")]
        public List<Data> Data { get; set; }
    }
    public class Bit : DataItemBase
    {
        [XmlAttribute(AttributeName = "index")]
        public string Index { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }
