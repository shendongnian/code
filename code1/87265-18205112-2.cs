        public static IEnumerable<IList<T>> Partition<T>(this IEnumerable<T> source, int size) {
            var partition = new List<T>( size);
            foreach(var t in source) {
                partition.Add( t);
                if( partition.Count == size) {
                    yield return partition;
                    partition = new List<T>( size);
                }
            }
            if (partition.Count > 0) {
                yield return partition;
            }
        }
