    public class Line{
        private Line(Coordinate c1 = null, Coordinate c2 = null, Point3d p1 = null, Point3d p2 = null)
        {}
        
        public static Line CreateLine(Coordinate c1 = null, Coordinate c2 = null, Point3d p1 = null, Point3d p2 = null)
        {
            if (/* favorable condition*/)
                return new Line(c1, c2, p1, p2);
            return null;
        }
    }
