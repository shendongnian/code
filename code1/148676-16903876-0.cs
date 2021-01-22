    public class RoundRobinList<T>
    {
        private readonly IList<T> _list;
        private readonly int _size;
        private int _position;
        public RoundRobinList(IList<T> list)
        {
            if (!list.Any())
                throw new NullReferenceException("list");
            _list = new List<T>(list);
            _size = _list.Count;            
        }
        public T Next()
        {
            if (_size == 1)
                return _list[0];
            Interlocked.Increment(ref _position);
            var mod = _position % _size;
            return _list[mod];
        }
    }
