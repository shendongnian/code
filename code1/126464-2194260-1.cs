    class Point
    {
        private readonly int x, y;
    
        public int X { get { return x; } }
   
        public int Y { get { return y; } }
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    var p = new Point(1, 2);
