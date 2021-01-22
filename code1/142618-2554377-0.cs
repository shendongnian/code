    public class MinLengthList : IList<String>
    {
        private IList<string> _list;
        private int _minLength;
        public MinLengthList(int min_length, IList<String> inner_list)
        {
            _list = inner_list;
            _minLength = min_length;
        }
        protected virtual void ValidateLength(String item)
        {
            if (item.Length < _minLength)
                throw new ArgumentException("Item is too short");
        }
        #region IList<string> Members
        public int IndexOf(string item)
        {
            return _list.IndexOf(item);
        }
        public void Insert(int index, string item)
        {
            ValidateLength(item);
            _list.Insert(index, item);
        }
        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }
        public string this[int index]
        {
            get
            {
                return _list[index];
            }
            set
            {
                ValidateLength(value);
                _list[index] = value;
            }
        }
        #endregion
        #region ICollection<string> Members
        public void Add(string item)
        {
            ValidateLength(item);
            _list.Add(item);
        }
        public void Clear()
        {
            _list.Clear();
        }
        public bool Contains(string item)
        {
            return _list.Contains(item);
        }
        public void CopyTo(string[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }
        public int Count
        {
            get { return _list.Count; }
        }
        public bool IsReadOnly
        {
            get { return _list.IsReadOnly; }
        }
        public bool Remove(string item)
        {
            return _list.Remove(item);
        }
        #endregion
        #region IEnumerable<string> Members
        public IEnumerator<string> GetEnumerator()
        {
            return _list.GetEnumerator();
        }
        #endregion
        #region IEnumerable Members
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_list).GetEnumerator();
        }
        #endregion
    }
    public class Program
    {
        static void Main()
        {
            IList<String> custom_list = new MinLengthList(5, new List<String>());
            custom_list.Add("hi");
        }
    }
