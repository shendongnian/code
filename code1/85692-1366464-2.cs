    public sealed class DictionaryBackedSet<T> : IEnumerable<T>
    {
        private readonly Dictionary<T, int> dictionary = new Dictionary<T, int>();
        public IEnumerator<T> GetEnumerator()
        {
            return dictionary.Keys.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public bool Add(T item)
        {
            if (Contains(item))
            {
                return false;
            }
            dictionary.Add(item, 0);
            return true;
        }
        public bool Contains(T item)
        {
            return dictionary.ContainsKey(item);
        }
        // etc
    }
