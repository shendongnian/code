    struct Point 
    {
     public int X;
     public int Y;
     public Point(int x, int y) { X=x; Y=y; }
    }
    double Distance(Point p1, Point p2)
    {
        return Math.Sqrt( Math.Pow(p1.X-p2.X,2) + Math.Pow(p1.Y-p2.Y,2) );
    }
    var list = new List<Point>{...};
