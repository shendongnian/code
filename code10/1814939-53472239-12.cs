    public abstract class : Shape
    {
        public abstract double Area { get; }
    }
    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public override double Area => Width * Height;
    }
    public class Circle : Shape
    {
        public double Radius { get; set; }
        public override double Area => Radius * Radius * Math.Pi;
    }
