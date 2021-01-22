    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Serialization;
    
    
    [XmlRoot("answer")]
    public class Answer
    {
        [XmlElement]
        public List<Player> Players { get; set; }
    }
    
    public class Player
    {
        [XmlAttribute("id")]
        public int ID { get; set; }
    
        [XmlElement]
        public List<Coordinate> Coordinates { get; set; }
    
        [XmlElement("action")]
        public PlayerAction Action { get; set; }
    }
    
    public class PlayerAction
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
    
        [XmlAnyElement]
        public XmlElement[] ActionContents { get; set; }
    }
    
    public enum Axis
    {
        [XmlEnum("x")]
        X,
        [XmlEnum("y")]
        Y,
        [XmlEnum("z")]
        Z
    }
    
    public class Coordinate
    {
        [XmlAttribute("axis")]
        public Axis Axis { get; set; }
    
        [XmlText]
        public double Value { get; set; }
    }
