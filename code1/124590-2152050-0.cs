    // assume a hypothetical class Position
    
    public class Circle
    {
        private int _radius;
        private int _xpos;
        private int _ypos;
    
        public int Radius { get { return _radius; } }
        public Position Center { get { return new Position(_xpos, _ypos); } }
    
        public bool PointInCircle(Position other)
        {
             return distance(this.Center, other) < this.Radius;
        }
    }
