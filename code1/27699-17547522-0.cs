    using System.Collections.Generic;
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Partitions an enumerable into individual pages of a specified size, still scanning the source enumerable just once
        /// </summary>
        /// <typeparam name="T">The element type</typeparam>
        /// <param name="enumerable">The source enumerable</param>
        /// <param name="pageSize">The number of elements to return in each page</param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Partition<T>(this IEnumerable<T> enumerable, int pageSize)
        {
            var enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var indexWithinPage = new IntByRef { Value = 0 };
                yield return SubPartition(enumerator, pageSize, indexWithinPage);
                // Continue iterating through any remaining items in the page, to align with the start of the next page
                for (; indexWithinPage.Value < pageSize; indexWithinPage.Value++)
                {
                    if (!enumerator.MoveNext())
                    {
                        yield break;
                    }
                }
            }
        }
        private static IEnumerable<T> SubPartition<T>(IEnumerator<T> enumerator, int pageSize, IntByRef index)
        {
            for (; index.Value < pageSize; index.Value++)
            {
                yield return enumerator.Current;
                if (!enumerator.MoveNext())
                {
                    yield break;
                }
            }
        }
        
        private class IntByRef
        {
            public int Value { get; set; }
        }
    }
