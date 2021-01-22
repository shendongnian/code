    [WebService(Namespace = "http://webservices.plattformad.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class PointService : WebService
    {
        [WebMethod]
        public Points GetPoints()
        {
            return new Points(new List<Point>
            {
                new Point(0, 2),
                new Point(5, 3)
            });
        }
    }
    
    [Serializable]
    public sealed class Point
    {
        private readonly int x;
    
        private readonly int y;
    
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    
        private Point()
        {
        }
    
        [XmlAttribute]
        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
            }
        }
    
        [XmlAttribute]
        public int Y
        {
            get
            {
                return this.y;
            }
            set
            {
            }
        }
    }
    
    [Serializable]
    [XmlRoot("Points")]
    public sealed class Points
    {
        private readonly List<Point> points;
    
        public Points(List<Point> points)
        {
            this.points = points;
        }
        private Points()
        {
        }
    
        [XmlElement("Point")]
        public List<Point> ThePoints
        {
            get
            {
                return this.points;
            }
    
            set
            {
            }
        }
    }
