    // Unchecked code
    public class OrderedHashSet<T> : IEnumerable<T> {
        int currentIndex = 0;
        Dictionary<T, index> items = new Dictionary<T, index>();
 
        public bool Add(T item) {
            if (Contains(item))
                return false;
            items[item] = currentIndex++;
            return true;
        }
        public bool Contains(T item) {
            return items.ContainsKey(item);
        }
        public IEnumerator<T> GetEnumerator() {
            return items.Keys.OrderBy(key => items[key]).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
