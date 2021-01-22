    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    namespace mattmc3.Common.Collections.Generic {
        public interface IOrderedDictionary<TKey, TValue> : IDictionary<TKey, TValue>, IOrderedDictionary {
            new TValue this[int index] { get; set; }
            new TValue this[TKey key] { get; set; }
            new int Count { get; }
            new ICollection<TKey> Keys { get; }
            new ICollection<TValue> Values { get; }
            new void Add(TKey key, TValue value);
            new void Clear();
            void Insert(int index, TKey key, TValue value);
            int IndexOf(TKey key);
            bool ContainsValue(TValue value);
            bool ContainsValue(TValue value, IEqualityComparer<TValue> comparer);
            new bool ContainsKey(TKey key);
            KeyValuePair<TKey, TValue> GetItem(int index);
            new IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator();
            new bool Remove(TKey key);
            new void RemoveAt(int index);
            new bool TryGetValue(TKey key, out TValue value);
        }
    }
