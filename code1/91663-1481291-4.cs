    [DebuggerDisplay("Count = {Count}")]
    public class SparseArray<T>: IList<T>
    {
        Dictionary<int, T> _Array = new Dictionary<int, T>();
        int _Length = 0;
        public SparseArray(string jsonArray)
        {
            var jss = new JavaScriptSerializer();
            var objs = jss.Deserialize<object[]>(jsonArray);
            
            for (int i = 0; i < objs.Length; i++)
            {
                if (objs[i] is Dictionary<string, object>)
                {
                    // If the undefined object {undefined:null} is found, don't add the element
                    var undefined = (Dictionary<string, object>)objs[i];
                    if (undefined.ContainsKey("undefined") && undefined["undefined"] == null)
                    {
                        _Length++;
                        continue;
                    }
                }
                T val;
                // The object being must be serializable by the JavaScriptSerializer
                // Or at the very least, be convertible from one type to another
                // by implementing IConvertible.
                try
                {
                    val = (T)objs[i];
                }
                catch (InvalidCastException)
                {
                    val = (T)Convert.ChangeType(objs[i], typeof(T));
                }
                _Array.Add(_Length, val);
                _Length++;
            }
        }
        public SparseArray(int length)
        {
            // Initializes the array so it behaves the same way as a standard array when initialized.
            for (int i = 0; i < length; i++)
            {
                _Array.Add(i, default(T));
            }
            _Length = length;
        }
        public bool ContainsIndex(int index)
        {
            return _Array.ContainsKey(index);
        }
        #region IList<T> Members
        public int IndexOf(T item)
        {
            foreach (KeyValuePair<int, T> pair in _Array)
            {
                if (pair.Value.Equals(item))
                    return pair.Key;
            }
            return -1;
        }
        public T this[int index]
        {
            get {
                if (_Array.ContainsKey(index))
                    return _Array[index];
                else
                    throw new IndexNotFoundException(index);
            }
            set { _Array[index] = value; }
        }              
        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }
        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region ICollection<T> Members
        public void Add(T item)
        {
            _Array.Add(_Length, item);
            _Length++;
        }
        public void Clear()
        {
            _Array.Clear();
            _Length = 0;
        }
        public bool Contains(T item)
        {
            return _Array.ContainsValue(item);
        }        
        public int Count
        {
            get { return _Length; }
        }
        public bool IsReadOnly
        {
            get { return false; }
        }
        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region IEnumerable<T> Members
        public IEnumerator<T> GetEnumerator()
        {
            return _Array.Values.GetEnumerator();
        }
        #endregion
        #region IEnumerable Members
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _Array.Values.GetEnumerator();
        }
        #endregion
    }
