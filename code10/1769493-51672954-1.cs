    public class CartesianCoord
    {
        public double X { get; set; }
        public double Y { get; set; }
        public PolarCoord ToPolarCoord()
        {
            PolarCoord p = new PolarCoord();
            p.Radius = Math.Sqrt(X * X + Y * Y);
            p.Angle = Math.Atan2(Y / X);
            return p;
        }
    }
    public class PolarCoord
    {
        public double Radius { get; set; }
        public double Angle { get; set; }
        public double AngleDegree { get { return (this.Angle * 360) / (Math.PI * 2); } set { this.Angle = (value * 2 * Math.PI) / 360; } }
        public CartesianCoord ToCartesianCoors()
        {
            CartesianCoord c = new CartesianCoord();
            c.X = this.Radius * Math.Cos(Angle);
            c.Y = this.Radius * Math.Sin(Angle);
            return c;
        }
    }
    static void Main()
    {
        CartesianCoord c = new CartesianCoord() { X = 12, Y = 5 };
        Console.WriteLine("Cartesian Coords - X: {0}, Y: {1}", c.X, c.Y);
        PolarCoord p = c.ToPolarCoord();
        Console.WriteLine("Polar Coords - Arc: {0} ({1}°), Radius: {2} ", p.Angle, p.AngleDegree, p.Radius);
        CartesianCoord c2 = p.ToCartesianCoors();
        Console.WriteLine("Cartesian Coords - X: {0}, Y: {1}", c2.X, c2.Y);
    }
