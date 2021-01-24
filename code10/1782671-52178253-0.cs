    struct Triangle {
        // all your need for a triangle is three points, isn't it?
        public Point PointA { get; }
        public Point PointB { get; }
        public Point PointC { get; }
        public Triangle(Point a, Point b, Point c) {
            PointA = a;
            PointB = b;
            PointC = c;
        }
    }
