    struct Point
    {
        public double X;
        public double Y;
        public string Name;
    }
    
    static Point Sample0() => new Point().To(out var p).With(
    	p.X = 123,
    	p.Y = 321,
    	p.Name = "abc"
    ).Let(p);
