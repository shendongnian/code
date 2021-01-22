    using System;
    using System.Collections.Generic;
     
    namespace SampleApp
    {
        internal class Program
        {
            private static void Main()
            {
                List<double> data = new List<double> {1, 2, 3, 4, 5, 6};
     
                double mean = data.Mean();
                double variance = data.Variance();
                double sd = data.StandardDeviation();
     
                Console.WriteLine("Mean: {0}, Variance: {1}, SD: {2}", mean, variance, sd);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
     
        public static class MyListExtensions
        {
            public static double Mean(this List<double> values)
            {
                return values.Count == 0 ? 0 : values.Mean(0, values.Count);
            }
     
            public static double Mean(this List<double> values, int start, int end)
            {
                double s = 0;
     
                for (int i = start; i < end; i++)
                {
                    s += values[i];
                }
     
                return s / (end - start);
            }
     
            public static double Variance(this List<double> values)
            {
                return values.Variance(values.Mean(), 0, values.Count);
            }
     
            public static double Variance(this List<double> values, double mean)
            {
                return values.Variance(mean, 0, values.Count);
            }
     
            public static double Variance(this List<double> values, double mean, int start, int end)
            {
                double variance = 0;
     
                for (int i = start; i < end; i++)
                {
                    variance += Math.Pow((values[i] - mean), 2);
                }
     
                int n = end - start;
                if (start > 0) n -= 1;
     
                return variance / (n);
            }
     
            public static double StandardDeviation(this List<double> values)
            {
                return values.Count == 0 ? 0 : values.StandardDeviation(0, values.Count);
            }
     
            public static double StandardDeviation(this List<double> values, int start, int end)
            {
                double mean = values.Mean(start, end);
                double variance = values.Variance(mean, start, end);
     
                return Math.Sqrt(variance);
            }
        }
    }
