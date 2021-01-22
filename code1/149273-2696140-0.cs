    [XmlRoot("gesture")]
    public class Gesture
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlElement("point")]
        public List<Point> Points { get; set; }
        [XmlElement("transformedPoint")]
        public List<Point> TransformedPoints { get; set; }    
        public Gesture()
        {
            this.Points = new List<Point>();
        }
        public Gesture(List<Point> Points, String Name)
        {
            this.Points = new List<Point>(Points);
            this.Name = Name;
        }
    }
