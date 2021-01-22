    public class NormalDeviate : UniformDeviate
    {
        double mean;
        double standardDeviation;
        double storedValue;
    
        /// <summary>
        /// Initializes a new instance of the <see cref="NormalDeviate"/> class.
        /// </summary>
        /// <param name="mean">The mean.</param>
        /// <param name="standardDeviation">The standard deviation. The distance from the mean where 78.2% of the samples lie.</param>
        /// <param name="seed">The seed.</param>
        public NormalDeviate(double mean, double standardDeviation, ulong seed) : this(mean, standardDeviation, seed)
        {
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="NormalDeviate"/> class.
        /// </summary>
        /// <param name="mean">The mean.</param>
        /// <param name="standardDeviation">The standard deviation. The distance from the mean where 78.2% of the samples lie.</param>
        public NormalDeviate(double mean, double standardDeviation, ulong seed)
            : base(seed)
        {
            this.mean = mean;
            this.standardDeviation = standardDeviation;
            this.storedValue = 0d;
        }
    }
