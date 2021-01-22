    struct Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Point(int x, int y)
        {
            this = default(Point);
            X = x;
            Y = y;
        }
    }
