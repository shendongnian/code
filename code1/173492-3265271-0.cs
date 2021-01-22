    public class Vertex : Point
    {
        [XmlIgnore]
        public Point Normal { get; set; }
        [XmlAttribute]
        public float nX
        {
            get { return Normal.X; }
            set { Normal.X = value; }
        }
    
        //etc
    }
