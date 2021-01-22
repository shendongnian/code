    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class SafeDictionary<TK, TD>: IDictionary<TK, TD> {
        Dictionary<TK, TD> _underlying = new Dictionary<TK, TD>();
        public ICollection<TK> Keys => _underlying.Keys;
        public ICollection<TD> Values => _underlying.Values;
        public int Count => _underlying.Count;
        public bool IsReadOnly => false;
        public TD this[TK index] {
            get {
                TD data;
                if (_underlying.TryGetValue(index, out data)) {
                    return data;
                }
                _underlying[index] = default(TD);
                return default(TD);
            }
            set {
                _underlying[index] = value;
            }
        }
        public void CopyTo(KeyValuePair<TK, TD>[] array, int arrayIndex) {
            Array.Copy(_underlying.ToArray(), 0, array, arrayIndex,
                Math.Min(array.Length - arrayIndex, _underlying.Count));
        }
        public void Add(TK key, TD value) {
            _underlying[key] = value;
        }
        public void Add(KeyValuePair<TK, TD> item) {
            _underlying[item.Key] = item.Value;
        }
        public void Clear() {
            _underlying.Clear();
        }
        public bool Contains(KeyValuePair<TK, TD> item) {
            return _underlying.Contains(item);
        }
        public bool ContainsKey(TK key) {
            return _underlying.ContainsKey(key);
        }
        public IEnumerator<KeyValuePair<TK, TD>> GetEnumerator() {
            return _underlying.GetEnumerator();
        }
        public bool Remove(TK key) {
            return _underlying.Remove(key);
        }
        public bool Remove(KeyValuePair<TK, TD> item) {
            return _underlying.Remove(item.Key);
        }
        public bool TryGetValue(TK key, out TD value) {
            return _underlying.TryGetValue(key, out value);
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return _underlying.GetEnumerator();
        }
    }
