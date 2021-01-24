    public abstract class Shape
    {
        public abstract double Area { get; }
    }
    public class Circle : Shape
    {
        public Circle(double radius)
        {
            Radius = radius;
        }
        private double Radius { get; set; }
        public override double Area => 3.14 * Math.Pow(Radius, 2);
    }
    public class Square : Shape
    {
        public Square(double edge)
        {
            Edge = edge;
        }
        private double Edge { get; set; }
        public override double Area => Math.Pow(Edge, 2);
    }
