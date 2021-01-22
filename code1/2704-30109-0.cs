    public struct Line
    {
        public static Line Empty;
        private PointF p1;
        private PointF p2;
        public Line(PointF p1, PointF p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }
        public PointF P1
        {
            get { return p1; }
            set { p1 = value; }
        }
        public PointF P2
        {
            get { return p2; }
            set { p2 = value; }
        }
        public float X1
        {
            get { return p1.X; }
            set { p1.X = value; }
        }
        public float X2
        {
            get { return p2.X; }
            set { p2.X = value; }
        }
        public float Y1
        {
            get { return p1.Y; }
            set { p1.Y = value; }
        }
        public float Y2
        {
            get { return p2.Y; }
            set { p2.Y = value; }
        }
    }
    public struct Polygon: IEnumerable<PointF>
    {
        private PointF[] points;
        public Polygon(PointF[] points)
        {
            this.points = points;
        }
        public PointF[] Points
        {
            get { return points; }
            set { points = value; }
        }
        public int Length
        {
            get { return points.Length; }
        }
        public PointF this[int index]
        {
            get { return points[index]; }
            set { points[index] = value; }
        }
        public static implicit operator PointF[](Polygon polygon)
        {
            return polygon.points;
        }
        public static implicit operator Polygon(PointF[] points)
        {
            return new Polygon(points);
        }
        IEnumerator<PointF> IEnumerable<PointF>.GetEnumerator()
        {
            return (IEnumerator<PointF>)points.GetEnumerator();
        }
        public IEnumerator GetEnumerator()
        {
            return points.GetEnumerator();
        }
    }
    public enum Intersection
    {
        None,
        Tangent,
        Intersection,
        Containment
    }
    public static class Geometry
    {
        public static Intersection IntersectionOf(Line line, Polygon polygon)
        {
            if (polygon.Length == 0)
            {
                return Intersection.None;
            }
            if (polygon.Length == 1)
            {
                return IntersectionOf(polygon[0], line);
            }
            bool tangent = false;
            for (int index = 0; index < polygon.Length; index++)
            {
                int index2 = (index + 1)%polygon.Length;
                Intersection intersection = IntersectionOf(line, new Line(polygon[index], polygon[index2]));
                if (intersection == Intersection.Intersection)
                {
                    return intersection;
                }
                if (intersection == Intersection.Tangent)
                {
                    tangent = true;
                }
            }
            return tangent ? Intersection.Tangent : IntersectionOf(line.P1, polygon);
        }
        public static Intersection IntersectionOf(PointF point, Polygon polygon)
        {
            switch (polygon.Length)
            {
                case 0:
                    return Intersection.None;
                case 1:
                    if (polygon[0].X == point.X && polygon[0].Y == point.Y)
                    {
                        return Intersection.Tangent;
                    }
                    else
                    {
                        return Intersection.None;
                    }
                case 2:
                    return IntersectionOf(point, new Line(polygon[0], polygon[1]));
            }
            int counter = 0;
            int i;
            PointF p1;
            int n = polygon.Length;
            p1 = polygon[0];
            if (point == p1)
            {
                return Intersection.Tangent;
            }
            for (i = 1; i <= n; i++)
            {
                PointF p2 = polygon[i % n];
                if (point == p2)
                {
                    return Intersection.Tangent;
                }
                if (point.Y > Math.Min(p1.Y, p2.Y))
                {
                    if (point.Y <= Math.Max(p1.Y, p2.Y))
                    {
                        if (point.X <= Math.Max(p1.X, p2.X))
                        {
                            if (p1.Y != p2.Y)
                            {
                                double xinters = (point.Y - p1.Y) * (p2.X - p1.X) / (p2.Y - p1.Y) + p1.X;
                                if (p1.X == p2.X || point.X <= xinters)
                                    counter++;
                            }
                        }
                    }
                }
                p1 = p2;
            }
            return (counter % 2 == 1) ? Intersection.Containment : Intersection.None;
        }
        public static Intersection IntersectionOf(PointF point, Line line)
        {
            float bottomY = Math.Min(line.Y1, line.Y2);
            float topY = Math.Max(line.Y1, line.Y2);
            bool heightIsRight = point.Y >= bottomY &&
                                 point.Y <= topY;
            //Vertical line, slope is divideByZero error!
            if (line.X1 == line.X2)
            {
                if (point.X == line.X1 && heightIsRight)
                {
                    return Intersection.Tangent;
                }
                else
                {
                    return Intersection.None;
                }
            }
            float slope = (line.X2 - line.X1)/(line.Y2 - line.Y1);
            bool onLine = (line.Y1 - point.Y) == (slope*(line.X1 - point.X));
            if (onLine && heightIsRight)
            {
                return Intersection.Tangent;
            }
            else
            {
                return Intersection.None;
            }
        }
    }
