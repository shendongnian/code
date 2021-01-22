        public static long Average(this IEnumerable<long> longs)
        {
            long mean = 0;
            long count = longs.Count();
            foreach (var val in longs)
            {
                mean += val / count;
            }
            return mean;
        }
