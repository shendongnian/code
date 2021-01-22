        public static List<PointD> Transform(List<double> X, List<double> Y)
        {
            if (X == null || X.Count == 0)
            {
                throw new ArgumentException("X must not be empty");
            }
            if (Y == null || Y.Count == 0)
            {
                throw new ArgumentException("Y must not be empty");
            }
            if (X.Count != Y.Count)
            {
                throw new ArgumentException("X and Y must be of equal length");
            }
            var results = new List<PointD>();
            for (int i = 0; i < X.Count; i++)
            {
                results.Add(new PointD { X = X[i], Y = Y[i]});
            }
            return results;
        }
