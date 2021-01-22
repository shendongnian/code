    public class CSCodeEvaler
    {
        public double EvalCode()
        {
            return last = Convert.ToDouble(%formula%);
        }
        public double last = 0;
        public const double pi = Math.PI;
        public const double e = Math.E;
        public double sin(double value) { return Math.Sin(value); }
        public double cos(double value) { return Math.Cos(value); }
        public double tan(double value) { return Math.Tan(value); }
        ...
