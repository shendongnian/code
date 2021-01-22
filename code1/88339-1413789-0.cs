    class Triangle
    {
        public Triangle(double b, double h)
        {
            Base = b;
            Height = h;
        }
        public double Base { get; set; }
        public double Height { get; set; }
        public double CalculateArea()
        {
            return (Base * Height) / 2;
        }
    }
