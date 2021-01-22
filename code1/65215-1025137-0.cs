       public static IEnumerable<T> GetIndexedItems2<T>(this IEnumerable<T> collection,    IEnumerable<int> indices) {
            int skipped = 0;
            foreach (int index in indices) {
                int offset = index - skipped;
                collection = collection.Skip(offset);
                skipped += offset;
                yield return collection.First();
            }
        }
