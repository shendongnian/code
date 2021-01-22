        private double _epsilon = 10E-9;
        /// <summary>
        /// Checks if the distance between two doubles is within an epsilon.
        /// In general this should be used for determining equality between doubles.
        /// </summary>
        /// <param name="x0">The orgin of intrest</param>
        /// <param name="x"> The point of intrest</param>
        /// <param name="epsilon">The minimum distance between the points</param>
        /// <returns>Returns true iff x  in (x0-epsilon, x0+epsilon)</returns>
        public static bool IsInNeghborhood(double x0, double x, double epsilon) => Abs(x0 - x) < epsilon;
        
        public static bool AreEqual(double v0, double v1) => IsInNeghborhood(v0, v1, _epsilon);
