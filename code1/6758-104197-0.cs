    class TwoDPoint : System.Object
    {
        public readonly int x, y;
    
        public TwoDPoint(int x, int y)  //constructor
        {
            this.x = x;
            this.y = y;
        }
    
        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }
    
            // If parameter cannot be cast to Point return false.
            TwoDPoint p = obj as TwoDPoint;
            if ((System.Object)p == null)
            {
                return false;
            }
    
            // Return true if the fields match:
            return (x == p.x) && (y == p.y);
        }
    
        public bool Equals(TwoDPoint p)
        {
            // If parameter is null return false:
            if ((object)p == null)
            {
                return false;
            }
    
            // Return true if the fields match:
            return (x == p.x) && (y == p.y);
        }
    
        public override int GetHashCode()
        {
            return x ^ y;
        }
    }
