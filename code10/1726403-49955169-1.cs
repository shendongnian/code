    public class ChildPoint
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
    public class RootPoint
    {
        public int IdPoiType { get; set; }
        public List<ChildPoints> Points { get; set; }
    }
