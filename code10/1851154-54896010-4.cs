    public class Ellipse
    {
        public PointF Center { get; set; }
        public float A { get; set; }  /* horizontal semiaxis */
        public float B { get; set; }  /* vertical semiaxis */
        public Ellipse(PointF center, float a, float b)
        {
            this.Center=center;
            this.A=a;
            this.B=b;
        }
        public PointF GetXYWhenT(float t_rad)
        {
            float x = this.Center.X+(this.A*(float)Math.Cos(t_rad));
            float y = this.Center.Y+(this.B*(float)Math.Sin(t_rad));
            return new PointF(x, y);
        }
        public float GetParameterFromPoint(PointF point)
        {
            var x = point.X-Center.X;
            var y = point.Y-Center.Y;
            // Since x=a*cos(t) and y=b*sin(t), then
            // tan(t) = sin(t)/cos(t) = (y/b) / (x/a)
            return (float)Math.Atan2(A*y, B*x);
        }
    }
    class Program
    {
        static readonly Random rng = new Random();
        static void Main(string[] args)
        {
            var center = new PointF(35.5f, -12.2f);
            var ellipse = new Ellipse(center, 18f, 44f);
            // Get t between -π and +π
            var t = (float)(2*Math.PI*rng.NextDouble()-Math.PI);
            var point = ellipse.GetXYWhenT(t);
            var t_check = ellipse.GetParameterFromPoint(point);
            Debug.WriteLine($"t={t}, t_check={t_check}");
            // t=-0.7434262, t_check=-0.7434263
        }
    }
