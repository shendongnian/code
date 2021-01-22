        public class OrderdDictionary<T, K>
        {
            public OrderedDictionary UnderlyingCollection { get; } = new OrderedDictionary();
            public K this[T key]
            {
                get
                {
                    return (K)UnderlyingCollection[key];
                }
                set
                {
                    UnderlyingCollection[key] = value;
                }
            }
            public K this[int index]
            {
                get
                {
                    return (K)UnderlyingCollection[index];
                }
                set
                {
                    UnderlyingCollection[index] = value;
                }
            }
            public ICollection<T> Keys => UnderlyingCollection.Keys.OfType<T>().ToList();
            public ICollection<K> Values => UnderlyingCollection.Values.OfType<K>().ToList();
            public bool IsReadOnly => UnderlyingCollection.IsReadOnly;
            public int Count => UnderlyingCollection.Count;
            public IDictionaryEnumerator GetEnumerator() => UnderlyingCollection.GetEnumerator();
            public void Insert(int index, T key, K value) => UnderlyingCollection.Insert(index, key, value);
            public void RemoveAt(int index) => UnderlyingCollection.RemoveAt(index);
            public bool Contains(T key) => UnderlyingCollection.Contains(key);
            public void Add(T key, K value) => UnderlyingCollection.Add(key, value);
            public void Clear() => UnderlyingCollection.Clear();
            public void Remove(T key) => UnderlyingCollection.Remove(key);
            public void CopyTo(Array array, int index) => UnderlyingCollection.CopyTo(array, index);
        }
