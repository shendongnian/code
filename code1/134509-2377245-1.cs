    public class PointCoord {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }
    public class Point : PointCoord {  
        public Guid Id { get; set; }
    }
