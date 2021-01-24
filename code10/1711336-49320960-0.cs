    public static class EnumerableExtensions
    {
        /// <summary> 
        /// Splits the values in an enumerable by position into batches of the specified size 
        /// </summary> 
        public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> items, int batchSize)
        {
            using (var e = items.GetEnumerator())
            {
                while (e.MoveNext()) // check before entering the loop 
                {
                    yield return BatchOf(e, batchSize);
                }
            }
        }
        private static IEnumerable<T> BatchOf<T>(IEnumerator<T> e, int batchSize)
        {
            for (var i = 0; i < batchSize; i++)
            {
                if (i > 0 && !e.MoveNext()) // already checked once before entering the loop / so only check on subsequent iterations 
                {
                    yield break;
                }
                yield return e.Current;
            }
        }
    }
