    [XmlRoot(ElementName = "location")]
    public class Location
    {
        [XmlAttribute(AttributeName = "path")]
        public string Path { get; set; }
    }
    [XmlRoot(ElementName = "orderedfields")]
    public class Orderedfields
    {
        [XmlElement(ElementName = "type")]
        public List<string> Type { get; set; }
    }
    [XmlRoot(ElementName = "version")]
    public class Version
    {
        [XmlElement(ElementName = "location")]
        public Location Location { get; set; }
        [XmlElement(ElementName = "numberOfFields")]
        public string NumberOfFields { get; set; }
        [XmlElement(ElementName = "orderedfields")]
        public Orderedfields Orderedfields { get; set; }
        [XmlAttribute(AttributeName = "number")]
        public string Number { get; set; }
    }
    [XmlRoot(ElementName = "versions")]
    public class Versions
    {
        [XmlElement(ElementName = "version")]
        public List<Version> Version { get; set; }
    }
    [XmlRoot(ElementName = "dip")]
    public class Dip
    {
        [XmlElement(ElementName = "versions")]
        public Versions Versions { get; set; }
    }
