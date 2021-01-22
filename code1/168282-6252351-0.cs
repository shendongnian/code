    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    public static class Extend
    {
        public static double StandardDeviation(this IEnumerable<double> values)
        {
            double avg = values.Average();
            return Math.Sqrt(values.Average(v=>Math.Pow(v-avg,2)));
        }
    }
