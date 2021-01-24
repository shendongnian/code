    static class EnumerableExtensions
    {
        /// <summary>
        /// Partitions the elements of a sequence into smaller collections according to a specified
        /// key selector function, optionally comparing the keys by using a specified comparer.
        /// Unlike GroupBy, this method does not produce a single collection for each key value.
        /// Instead, this method produces a collection for each consecutive set of matching keys.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> whose elements to partition.</param>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <param name="comparer">An <see cref="IEqualityComparer{T}"/> to compare keys.</param>
        /// <returns>
        /// An <b>IEnumerable{IGrouping{TKey, TSource}}</b> in C#
        /// or <b>IEnumerable(Of IGrouping(Of TKey, TSource))</b> in Visual Basic
        /// where each <see cref="IGrouping{TKey,TElement}"/> object contains a collection of objects and a key.
        /// </returns>
        public static IEnumerable<IGrouping<TKey, TSource>> Partition<TKey, TSource>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer = null)
        {
            if (comparer == null)
                comparer = EqualityComparer<TKey>.Default;
            using (var enumerator = source.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    var item = enumerator.Current;
                    var partitionKey = keySelector(item);
                    var itemsInPartition = new List<TSource> {item};
                    var lastPartitionKey = partitionKey;
                    while (enumerator.MoveNext())
                    {
                        item = enumerator.Current;
                        partitionKey = keySelector(item);
                        if (comparer.Equals(partitionKey, lastPartitionKey))
                        {
                            itemsInPartition.Add(item);
                        }
                        else
                        {
                            yield return new Grouping<TKey, TSource>(lastPartitionKey, itemsInPartition);
                            itemsInPartition = new List<TSource> {item};
                            lastPartitionKey = partitionKey;
                        }
                    }
                    yield return new Grouping<TKey, TSource>(lastPartitionKey, itemsInPartition);
                }
            }
        }
        // it's a shame there's no ready-made public implementation that will do this
        private class Grouping<TKey, TSource> : IGrouping<TKey, TSource>
        {
            public Grouping(TKey key, List<TSource> items)
            {
                _items = items;
                Key = key;
            }
            public TKey Key { get; }
            public IEnumerator<TSource> GetEnumerator()
            {
                return _items.GetEnumerator();
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return _items.GetEnumerator();
            }
            private readonly List<TSource> _items;
        }
    }
