    public class FieldProxyDictionary<TK, TV> : IDictionary<TK, TV>
    {
        private class FieldProxy<T>
        {
            private readonly Func<T> _getter;
            private readonly Action<T> _setter;
            public FieldProxy(Func<T> getter, Action<T> setter)
            {
                _getter = getter;
                _setter = setter;
            }
            public void Set(T value) => _setter(value);
            public static implicit operator T(FieldProxy<T> proxy) => proxy._getter();
        }
        private readonly Dictionary<TK, FieldProxy<TV>> _dictionary = new Dictionary<TK, FieldProxy<TV>>();
        public TV this[TK index] {
            get => _dictionary[index];
            set => _dictionary[index].Set(value);
        }
        public ICollection<TK> Keys => _dictionary.Keys;
        public ICollection<TV> Values => _dictionary.Values.Cast<TV>().ToArray();
        public int Count => _dictionary.Count;
        public bool IsReadOnly => false;
        [Obsolete("Adding items to " + nameof(FieldProxyDictionary<TK, TV>) + " is not supported. Use " + nameof(AddField) + " insted.")]
        public void Add(TK key, TV value) => throw new NotSupportedException($"Adding items to {nameof(FieldProxyDictionary<TK, TV>)} is not supported. Use {nameof(AddField)} insted.");
        [Obsolete("Adding items to " + nameof(FieldProxyDictionary<TK, TV>) + " is not supported. Use " + nameof(AddField) + " insted.")]
        public void Add(KeyValuePair<TK, TV> item) => throw new NotSupportedException($"Adding items to {nameof(FieldProxyDictionary<TK, TV>)} is not supported. Use {nameof(AddField)} insted.");
        public void AddField(TK index, object instance, string fieldName)
        {
            var field = instance.GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            TV getter() => (TV)field.GetValue(instance);
            void setter(TV value) => field.SetValue(instance, value);
            _dictionary[index] = new FieldProxy<TV>(getter, setter);
        }
        public void Clear() => _dictionary.Clear();
        public bool Contains(KeyValuePair<TK, TV> item) => _dictionary.TryGetValue(item.Key, out var value) && ((TV)value).Equals(item.Value);
        public bool ContainsKey(TK key) => _dictionary.ContainsKey(key);
        public void CopyTo(KeyValuePair<TK, TV>[] array, int arrayIndex) =>
            ((ICollection<KeyValuePair<TK, FieldProxy<TV>>>)_dictionary)
            .Select(proxy => new KeyValuePair<TK, TV>(proxy.Key, proxy.Value))
            .ToArray()
            .CopyTo(array, arrayIndex);
        public IEnumerator<KeyValuePair<TK, TV>> GetEnumerator() => _dictionary.Select(proxy => new KeyValuePair<TK, TV>(proxy.Key, proxy.Value)).GetEnumerator();
        public bool Remove(TK key) => _dictionary.Remove(key);
        public bool Remove(KeyValuePair<TK, TV> item) => _dictionary.TryGetValue(item.Key, out var value) && ((TV)value).Equals(item.Value) && _dictionary.Remove(item.Key);
        public bool TryGetValue(TK key, out TV value)
        {
            if (_dictionary.TryGetValue(key, out var proxy))
            {
                value = proxy;
                return true;
            }
            value = default(TV);
            return false;
        }
        IEnumerator IEnumerable.GetEnumerator() => _dictionary.Select(proxy => new KeyValuePair<TK, TV>(proxy.Key, proxy.Value)).GetEnumerator();
    }
    class VolleyballMatchSettlementContext
    {
        private int _TotalPoints1Set;
        private int _TotalPoints2Set;
        private int _TotalPoints3Set;
        private int _TotalPoints4Set;
        private int _TotalPoints5Set;
        public readonly FieldProxyDictionary<int, int> TotalPointCurrentSet;
        public VolleyballMatchSettlementContext()
        {
            TotalPointCurrentSet = new FieldProxyDictionary<int, int>();
            TotalPointCurrentSet.AddField(1, this, nameof(_TotalPoints1Set));
            TotalPointCurrentSet.AddField(2, this, nameof(_TotalPoints2Set));
            TotalPointCurrentSet.AddField(3, this, nameof(_TotalPoints3Set));
            TotalPointCurrentSet.AddField(4, this, nameof(_TotalPoints4Set));
            TotalPointCurrentSet.AddField(5, this, nameof(_TotalPoints5Set));
        }
    }
