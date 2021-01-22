    public abstract class DelegatedRandom
    {
        private Random _r = new Random();
        public int Next(int low, int high)
        {
            if (high >= low)
                throw new ArgumentOutOfRangeException("high");
            double rand = _r.NextDouble();
            rand = Transform(rand);
            if (rand > 1.0 || rand < 0) throw new Exception("internal error - expected transform to be between 0 and 1");
            return (int)((high - low) * rand) + low;
        }
        protected abstract Func<Double, Double> Transform { get; }
    }
    public class SinRandom : DelegatedRandom
    {
        private static double pihalf = Math.PI / 2;
        protected override Func<double, double> Transform
        {
            get { return r => Math.Sin(r * pihalf); }
        }
    }
    public class CosRandom : DelegatedRandom
    {
        private static double pihalf = Math.PI / 2;
        protected override Func<double, double> Transform
        {
            get { return r => Math.Cos(r * pihalf); }
        }
    }
    public class GammaRandom : DelegatedRandom
    {
        private double _gamma;
        public GammaRandom(double gamma)
        {
            if (gamma <= 0) throw new ArgumentOutOfRangeException("gamma");
            _gamma = gamma;
        }
        protected override Func<double, double> Transform
        {
            get { return r => Math.Pow(r, _gamma); }
        }
    }
