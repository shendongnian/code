    public class Calculator
    {
        public double A { get; set; };
        public double B { get; set; };
        public double C { get; set; };
        public double D { get; set; };
        public double Calculate(double x)
        {
            return A*x*x*x + B*x*x + C*x + D;
        }
    }
