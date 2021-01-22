        public static double StandardDeviation(double[] data)
        {
            double stdDev = 0;
            double sumAll = 0;
            double sumAllQ = 0;
            //Sum of x and sum of x²
            for (int i = 0; i < data.Length; i++)
            {
                double x = data[i];
                sumAll += x;
                sumAllQ += x * x;
            }
            //Mean (not used here)
            //double mean = 0;
            //mean = sumAll / (double)data.Length;
            //Standard deviation
            stdDev = System.Math.Sqrt(
                (sumAllQ -
                (sumAll * sumAll) / data.Length) *
                (1.0d / (data.Length - 1))
                );
            return stdDev;
        }
