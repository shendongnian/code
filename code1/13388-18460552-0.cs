    public class Gaussian
    {
         private bool _available;
         private double _nextGauss;
         private Random _rng;
         
         public Gaussian()
         {
             _rng = new Random();
         }
         
         public double RandomGauss()
         {
            if (_available)
            {
                _available = false;
                return _nextGauss;
            }
            
            double u1 = _rng.NextDouble();
            double u2 = _rng.NextDouble();
            double temp1 = Math.Sqrt(-2.0*Math.Log(u1));
            double temp2 = 2.0*Math.PI*u2;
            
            _nextGauss = temp1 * Math.Sin(temp2);
            _available = true;
            return temp1*Math.Cos(temp2);
         }
         
        public double RandomGauss(double mu, double sigma)
        {
            return mu + sigma*RandomGauss();
        }
        public double RandomGauss(double sigma)
        {
            return sigma*RandomGauss();
        }
    }
