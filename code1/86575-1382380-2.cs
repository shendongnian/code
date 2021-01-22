    public class SinBuddy
    {
        private Dictionary<double, double> _cachedSins
            = new Dictionary<double, double>();
        private const double _cacheStep = 0.01;
        private double _factor = Math.PI / 180.0;
    
        public SinBuddy()
        {
            for (double angleDegrees = 0; angleDegrees <= 360.0; 
                angleDegrees += _cacheStep)
            {
                double angleRadians = angleDegrees * _factor;
                _cachedSins.Add(angleDegrees, Math.Sin(angleRadians));
            }
        }
    
        public double CacheStep
        {
            get
            {
                return _cacheStep;
            }
        }
    
        public double SinLookup(double angleDegrees)
        {
            double value;
            if (_cachedSins.TryGetValue(angleDegrees, out value))
            {
                return value;
            }
            else
            {
                throw new ArgumentException(
                    String.Format("No cached Sin value for {0} degrees",
                    angleDegrees));
            }
        }
    
        public double Sin(double angleDegrees)
        {
            double angleRadians = angleDegrees * _factor;
            return Math.Sin(angleRadians);
        }
    }
