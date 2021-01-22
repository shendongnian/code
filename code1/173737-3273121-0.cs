    class MyDictionary : IDictionary<object, IntPtr>, IDisposable {
        private Dictionary<object, IntPtr> impl = new Dictionary<object, IntPtr>();
        public void Add(object key) {
            IntPtr mem = Marshal.AllocCoTaskMem(666);  // Something smarter here...
            impl.Add(key, mem);
        }
        public bool Remove(object key) {
            if (!impl.ContainsKey(key)) return false;
            Marshal.FreeCoTaskMem(impl[key]);
            return impl.Remove(key);
        }
        protected void Dispose(bool disposing) {
            foreach (IntPtr mem in impl.Values) Marshal.FreeCoTaskMem(mem);
            if (disposing) impl.Clear();
        }
        public void Dispose() { 
            Dispose(true); 
        }
        ~MyDictionary() { 
            Dispose(false); 
        }
    
        // Boilerplate
        public void Add(object key, IntPtr value) { throw new NotImplementedException(); }
        public void Add(KeyValuePair<object, IntPtr> item) { throw new NotImplementedException(); }
        public bool Remove(KeyValuePair<object, IntPtr> item) { throw new NotImplementedException(); }
        public bool ContainsKey(object key) { return impl.ContainsKey(key); }
        public ICollection<object> Keys { get { return impl.Keys; }}
        public bool TryGetValue(object key, out IntPtr value) { return impl.TryGetValue(key, out value); }
        public ICollection<IntPtr> Values { get {return impl.Values; }}
        public IntPtr this[object key] { get { return impl[key]; } set { impl[key] = value; } }
        public void Clear() { impl.Clear(); }
        public bool Contains(KeyValuePair<object, IntPtr> item) { return impl.Contains(item); }
        public void CopyTo(KeyValuePair<object, IntPtr>[] array, int arrayIndex) { (impl as ICollection<KeyValuePair<object, IntPtr>>).CopyTo(array, arrayIndex); }
        public int Count { get { return impl.Count; }}
        public bool IsReadOnly { get { return (impl as ICollection<KeyValuePair<object, IntPtr>>).IsReadOnly; } }
        public IEnumerator<KeyValuePair<object, IntPtr>> GetEnumerator() { return impl.GetEnumerator(); }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { return (impl as System.Collections.IEnumerable).GetEnumerator(); }
    }
