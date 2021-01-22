    /// <summary>
    /// Represents a pseudo-random number generator, a device that
    /// produces a sequence of numbers that are normally distributed.
    /// </summary>
    public class NormalDeviate : UniformDeviate
    {
        double mean;
        double standardDeviation;
        double storedValue = 0d;
    
        /// <summary>
        /// Initializes a new instance of the <see cref="NormalDeviate"/> class.
        /// </summary>
        /// <param name="mean">The mean.</param>
        /// <param name="standardDeviation">The standard deviation.</param>
        /// <param name="seed">The seed.</param>
        public NormalDeviate(double mean, double standardDeviation, ulong seed)
            : base(seed)
        {
            CommonInitialization(mean, standardDeviation);
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="NormalDeviate"/> class.
        /// </summary>
        /// <param name="mean">The mean.</param>
        /// <param name="standardDeviation">The standard deviation.</param>
        public NormalDeviate(double mean, double standardDeviation)
            : base()
        {
            CommonInitialization(mean, standardDeviation);
        }
        private void CommonInitialization(double mean, double standardDeviation)
        {
            this.mean = mean;
            this.standardDeviation = standardDeviation;
        }
    }
