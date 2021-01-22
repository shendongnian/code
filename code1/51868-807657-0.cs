    struct Point
    {
        public int X;
        public int Y;
        public Point(int x, int y) { X = x; Y = y; }
        
        public override bool Equals(object obj)
        {
            return obj is Point && Equals((Point)obj);
        }
        public bool Equals(Point other)
        {
            return (this.X == other.X && this.Y == other.Y);
        }
        public override int GetHashCode()
        {
            return X ^ Y;
        }
        public override string ToString()
        {
            return String.Format("({0}, {1})", X, Y);
        }
        public static bool operator ==(Point lhs, Point rhs)
        {
            return (lhs.Equals(rhs));
        }
        public static bool operator !=(Point lhs, Point rhs)
        {
            return !(lhs.Equals(rhs));
        }
        public static double Distance(Point p1, Point p2) 
        {
            return Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        }
    }
