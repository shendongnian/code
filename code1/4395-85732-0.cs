    class QueryableWrapper<T> : IQueryable<T>
    {
        private IQueryable<T> _InnerQueryable;
        private bool _HasExecuted;
        public QueryableWrapper(IQueryable<T> innerQueryable)
        {
            _InnerQueryable = innerQueryable;
        }
        public bool HasExecuted
        {
            get
            {
                return _HasExecuted;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            _HasExecuted = true;
            return _InnerQueryable.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Type ElementType
        {
            get { return _InnerQueryable.ElementType; }
        }
        public System.Linq.Expressions.Expression Expression
        {
            get { return _InnerQueryable.Expression; }
        }
        public IQueryProvider Provider
        {
            get { return _InnerQueryable.Provider; }
        }
    }
