    struct Vector {
        public float X;
        public float Y;
    }
    
    class BetterVector {
        public float X;
        public float Y;
        public Vector Optimized { get { return new Vector(X, Y); } }
    }
    
    class Object {
        public BetterVector Position { get; set; }
    }
