    [Serializable]
    [XmlRoot("rss")]
    public class MyRss
    {
        [XmlAttribute("version")]
        public string Version { get; set; }
        [XmlElement("channel")]
        public Channel Channel { get; set; }
        
        ...
    }
    [Serializable]
    public class Channel
    {
        [XmlElement("version")]
        public string Title { get; set; }
        [XmlArrayItem("item")]
        public List<Item> Items { get; set; }
        ...
    }
