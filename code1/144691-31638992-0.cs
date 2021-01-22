    public class Multiset<T>: ICollection<T>
    {
        private readonly Dictionary<T, int> data;
        public Multiset() 
        {
            data = new Dictionary<T, int>();
        }
        private Multiset(Dictionary<T, int> data)
        {
            this.data = data;
        }
        public void Add(T item)
        {
            int count = 0;
            data.TryGetValue(item, out count);
            count++;
            data[item] = count;
        }
        public void Clear()
        {
            data.Clear();
        }
        public Multiset<T> Except(Multiset<T> another)
        {
            Multiset<T> copy = new Multiset<T>(new Dictionary<T, int>(data));
            foreach (KeyValuePair<T, int> kvp in another.data)
            {
                int count;
                if (copy.data.TryGetValue(kvp.Key, out count))
                {
                    if (count > kvp.Value)
                    {
                        copy.data[kvp.Key] = count - kvp.Value;
                    }
                    else
                    {
                        copy.data.Remove(kvp.Key);
                    }
                }
            }
            return copy;
        }
        public Multiset<T> Intersection(Multiset<T> another)
        {
            Dictionary<T, int> newData = new Dictionary<T, int>();
            foreach (T t in data.Keys.Intersect(another.data.Keys))
            {
                newData[t] = Math.Min(data[t], another.data[t]);
            }
            return new Multiset<T>(newData);
        }
        public bool Contains(T item)
        {
            return data.ContainsKey(item);
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            foreach (KeyValuePair<T, int> kvp in data)
            {
                for (int i = 0; i < kvp.Value; i++)
                {
                    array[arrayIndex] = kvp.Key;
                    arrayIndex++;
                }
            }
        }
        public IEnumerable<T> Mode()
        {
            if (!data.Any())
            {
                return Enumerable.Empty<T>();
            }
            int modalFrequency = data.Values.Max();
            return data.Where(kvp => kvp.Value == modalFrequency).Select(kvp => kvp.Key);
        }
        public int Count
        {
            get 
            {
                return data.Values.Sum();
            }
        }
        public bool IsReadOnly
        {
            get 
            { 
                return false; 
            }
        }
        public bool Remove(T item)
        {
            int count;
            if (!data.TryGetValue(item, out count))
            {
                return false;
            }
            count--;
            if (count == 0)
            {
                data.Remove(item);
            }
            else
            {
                data[item] = count;
            }
            return true;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new MultisetEnumerator<T>(this);
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new MultisetEnumerator<T>(this);
        }
        private class MultisetEnumerator<T> : IEnumerator<T>
        {
            public MultisetEnumerator(Multiset<T> multiset)
            {
                this.multiset = multiset;
                baseEnumerator = multiset.data.GetEnumerator();
                index = 0;
            }
            private readonly Multiset<T> multiset;
            private readonly IEnumerator<KeyValuePair<T, int>> baseEnumerator;
            private int index;
            public T Current
            {
                get 
                {
                    return baseEnumerator.Current.Key;
                }
            }
            public void Dispose()
            {
                baseEnumerator.Dispose();
            }
            object System.Collections.IEnumerator.Current
            {
                get 
                {
                    return baseEnumerator.Current.Key;
                }
            }
            public bool MoveNext()
            {
                KeyValuePair<T, int> kvp = baseEnumerator.Current;
                if (index < (kvp.Value - 1))
                {
                    index++;
                    return true;
                }
                else
                {
                    bool result = baseEnumerator.MoveNext();
                    index = 0;
                    return result;
                }
            }
            public void Reset()
            {
                baseEnumerator.Reset();
            }
        }
    }
