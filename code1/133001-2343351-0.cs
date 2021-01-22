    struct Ratio
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Ratio (int x, int y) : this()
        {
            this.X = x;
            this.Y = y;
        }
        public double AsDouble() { return (double)X / (double)Y; }
    }
    Ratio[] commonRatios = { 
       new Ratio(16, 9),
       new Ratio(4, 3), 
       ... and so on, maybe the few hundred most common ratios here. 
    };
