    public class Indexable<T>
    {
        private readonly IList<T> _innerList;
        public Indexable(IList<T> innerList)
        {
            _innerList = innerList;
        }
        public T this[int index]
        {
            get { return _innerList[index]; }
            set { _innerList[index] = value; }
        }
    }
