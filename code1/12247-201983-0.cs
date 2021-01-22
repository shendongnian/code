    struct Id {
        public int Value;
    
        public Id(int value) { Value = value; }
    
        override int GetHashCode() { return Value.GetHashCode(); }
    
        // … Equals method.
    }
