    public class QueryTranslator<T> : IOrderedQueryable<T>
    {
        private Expression _expression = null;
        private QueryTranslatorProvider<T> _provider = null;
        public QueryTranslator(IQueryable source)
        {
            _expression = Expression.Constant(this);
            _provider = new QueryTranslatorProvider<T>(source);
        }
        public QueryTranslator(IQueryable source, Expression e)
        {
            if (e == null) throw new ArgumentNullException("e");
            _expression = e;
            _provider = new QueryTranslatorProvider<T>(source);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_provider.ExecuteEnumerable(this._expression)).GetEnumerator();
        }
        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _provider.ExecuteEnumerable(this._expression).GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(T); }
        }
        public Expression Expression
        {
            get { return _expression; }
        }
        public IQueryProvider Provider
        {
            get { return _provider; }
        }
    }
