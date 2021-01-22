    public static class ListExtensions
    {
        public static int BinarySearch<T, U>(this IList<T> tf, U target, Func<T, U> selector)
        {
            var lo = 0;
            var hi = (int)tf.Count - 1;
            var comp = Comparer<U>.Default;
            while (lo <= hi)
            {
                var median = lo + (hi - lo >> 1);
                var num = comp.Compare(selector(tf[median]), target);
                if (num == 0)
                    return median;
                if (num < 0)
                    lo = median + 1;
                else
                    hi = median - 1;
            }
            return ~lo;
        }
    }
