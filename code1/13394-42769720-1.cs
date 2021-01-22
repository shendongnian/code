        public static double Draw()
        {
            while (true)
            {
                // Get random values from interval [0,1]
                var x = _rand.NextDouble(); 
                var y = _rand.NextDouble(); 
                // Is the point (x,y) under the curve of the density function?
                if (y < f(x)) 
                    return x;
            }
        }
        // Normal (or gauss) distribution function
        public static double f(double x, double μ = 0.5, double σ = 0.2)
        {
            return 1d / Math.Sqrt(2 * σ * σ * Math.PI) * Math.Exp(-((x - μ) * (x - μ)) / (2 * σ * σ));
        }
