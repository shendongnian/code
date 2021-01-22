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
    var p1 = new Point(2,3);
    var p2 = new Point(-1,-1);
    var p3 = new Point(-1,-5);
    var p4 = new Point(-4,-5);
    var p5 = new Point(-1,-1);
    var list = new List<Point>{p1,p2,p3,p4,p5};
