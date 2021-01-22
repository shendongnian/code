        /// <summary>
        /// Finds the Gradient using the Least Squares Method
        /// </summary>
        /// <returns>The y intercept of a trendline of best fit through the data X and Y</returns>
        public decimal LeastSquaresGradient()
        {
           
            //The DataSetsMatch method ensures that X and Y 
            //(both List<decimal> in this situation) have the same number of elements
            if (!DataSetsMatch())
            {
                throw new ArgumentException("X and Y must contain the same number of elements");
            }
            //These variables are used store the variances of each point from its associated mean
            List<decimal> varX = new List<decimal>();
            List<decimal> varY = new List<decimal>();
            foreach (decimal x in X)
            {
                varX.Add(x - AverageX());
            }
            foreach (decimal y in Y)
            {
                varY.Add(y - AverageY());
            }
            decimal topLine = 0;
            decimal bottomLine = 0;
            for (int i = 0; i < X.Count; i++)
            {
                topLine += (varX[i] * varY[i]);
                bottomLine += (varX[i] * varX[i]);
            }
            if (bottomLine != 0)
            {
                return topLine / bottomLine;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// Finds the Y Intercept using the Least Squares Method
        /// </summary>
        /// <returns>The y intercept of a trendline of best fit through the data X and Y</returns>
        public decimal LeastSquaresYIntercept()
        {
            return AverageY() - (LeastSquaresGradient() * AverageX());
        }
        
        /// <summary>
        /// Averages the Y.
        /// </summary>
        /// <returns>The average of the List Y</returns>
        public decimal AverageX()
        {
            decimal temp = 0;
            foreach (decimal t in X)
            {
                temp += t;
            }
            if (X.Count == 0)
            {
                return 0;
            }
            return temp / X.Count;
        }
        /// <summary>
        /// Averages the Y.
        /// </summary>
        /// <returns>The average of the List Y</returns>
        public decimal AverageY()
        {
            decimal temp = 0;
            foreach (decimal t in Y)
            {
                temp += t;
            }
            if (Y.Count == 0)
            {
                return 0;
            }
            return temp / Y.Count;
        }
