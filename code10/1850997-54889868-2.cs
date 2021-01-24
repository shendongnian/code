    public static class EnumerableExtensions
    {
        public class AdjacentGrouping<K, T> : List<T>, IGrouping<K, T>
        {
            public AdjacentGrouping(K key) { Key = key; }
            public K Key { get; private set; }
        }
        public static IEnumerable<IGrouping<K, T>> GroupByAdjacent<T, K>(
                                this IEnumerable<T> sequence, Func<T, K> keySelector)
        {
            using (var it = sequence.GetEnumerator())
            {
                if (!it.MoveNext())
                    yield break;
                T curr = it.Current;
                K currKey = keySelector(curr);
                var currentCluster = new AdjacentGrouping<K, T>(currKey) { curr };
                while (it.MoveNext())
                {
                    curr = it.Current;
                    currKey = keySelector(curr);
                    if (!EqualityComparer<K>.Default.Equals(currKey, currentCluster.Key))
                    {
                        // start a new cluster
                        yield return currentCluster;
                        currentCluster = new ClusterGrouping<K, T>(currKey);
                    }
                    currentCluster.Add(curr);
                };
                yield return currentCluster;
            }
        }
    }
