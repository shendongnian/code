       public static IEnumerable<T> GetIndexedItems3<T>(this IEnumerable<T> collection, IEnumerable<int> indices) {
            foreach (int offset in indices.Distances()) {
                collection = collection.Skip(offset);
                yield return collection.First();
            }
        }
        public static IEnumerable<int> Distances(this IEnumerable<int> numbers) {
            int offset = 0;
            foreach (var number in numbers) {
                yield return number - offset;
                offset = number;
            }
        }
