    public class EnumEnumerator<T> : IEnumerator<T>, IEnumerable<T> {
        int _index;
        T[] _list;
        public EnumEnumerator() {
            if (!typeof(T).IsEnum)
                throw new NotSupportedException();
            _list = (T[])Enum.GetValues(typeof(T));
        }
        public T Current {
            get { return _list[_index]; }
        }
        public bool MoveNext() {
            if (_index + 1 >= _list.Length)
                return false;
            _index++;
            return true;
        }
        public bool MovePrevious() {
            if (_index <= 0)
                return false;
            _index--;
            return true;
        }
        public bool Seek(T item) {
            int i = Array.IndexOf<T>(_list, item);
            if (i >= 0) {
                _index = i;
                return true;
            } else
                return false;
        }
        public void Reset() {
            _index = 0;
        }
        public IEnumerator<T> GetEnumerator() {
            return ((IEnumerable<T>)_list).GetEnumerator();
        }
        void IDisposable.Dispose() { }
        object System.Collections.IEnumerator.Current {
            get { return Current; }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return _list.GetEnumerator();
        }
    }
