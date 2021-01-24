    public static Points _points { get; set; }
    
    struct Points
    {
        private int i; // 0 by default
        public static implicit operator Points(int value)
        {
            return new Points { i = value };
        }
        public static implicit operator string(Points value)
        {
            return value.i.ToString();
        }
        public static implicit operator int(Points value)
        {
            return value.i;
        }
    }
