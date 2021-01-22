    public class Gaussian : Random
    {
        
        public Gaussian():base()
        {
        }
        /// <summary>
        /// Obtains normally (Gaussian) distrubuted random numbers, using the Box-Muller
        /// transformation.  This transformation takes two uniformly distributed deviates
        /// within the unit circle, and transforms them into two independently distributed normal deviates.
        /// </summary>
        /// <param name="mu">The mean of the distribution.  Default is zero</param>
        /// <param name="sigma">The standard deviation of the distribution.  Default is one.</param>
        /// <returns></returns>
        public double RandomGauss(double mu = 0, double sigma = 1)
        {
            if (sigma <= 0)
                throw new ArgumentOutOfRangeException("sigma", "Must be greater than zero.");
            double u1 = base.NextDouble();
            double u2 = base.NextDouble();
            double temp1 = Math.Sqrt(-2 * Math.Log(u1));
            double temp2 = 2 * Math.PI * u2;
            return mu + sigma*(temp1 * Math.Cos(temp2));
        }
    }
