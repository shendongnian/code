    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x, int y):this()
        {
            this.X = x;
            this.Y = y;
        }
    }
    Point p = new Point(-1, -1);
    // ...
    p.X = newX;
    p.Y = newY;
