    public static class EnumerableExt
    {
        public static IEnumerable<IEnumerable<T>> Partition<T>(this IEnumerable<T> input, int blockSize)
        {
            var enumerator = input.GetEnumerator();
            while (enumerator.MoveNext())
            {
                yield return nextPartition(enumerator, blockSize);
            }
        }
        private static IEnumerable<T> nextPartition<T>(IEnumerator<T> enumerator, int blockSize)
        {
            do
            {
                yield return enumerator.Current;
            }
            while (--blockSize > 0 && enumerator.MoveNext());
        }
    }
