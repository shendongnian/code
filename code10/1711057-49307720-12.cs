    public class SafeList<T>
    {
        private readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();
        private readonly List<T> _list = new List<T>();
        public T this[int index]
        {
            get
            {
                T result = default(T);
                _lock.ExecuteRead(() => result = _list[index]);
                return result;
            }
        }
        public List<T> GetAll()
        {
            List<T> result = null;
            _lock.ExecuteRead(() => result = _list.ToList());
            return result;
        }
        public void ForEach(Action<T> action) => 
          _lock.ExecuteRead(() => _list.ForEach(action));
        public void Add(T item) => _lock.ExecuteWrite(() => _list.Add(item));
        public void AddRange(IEnumerable<T> items) => 
          _lock.ExecuteWrite(() => _list.AddRange(items));
    }
