    public sealed class Point
    {
        private readonly int _x;
        private readonly int _y;
        private readonly int _hash;
        public Point(int x, int y)
        {
            _x = x;
            _y = y;
            _hash = new HashCodeBuilder().
                Add(_x).
                Add(_y).
                GetHashCode();
        }
        public int X
        {
            get { return _x; }
        }
        public int Y
        {
            get { return _y; }
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Point);
        }
        public bool Equals(Point other)
        {
            if (other == null) return false;
            return (other._x == _x) && (other._y == _y);
        }
        public override int GetHashCode()
        {
            return _hash;
        }
    }
    
