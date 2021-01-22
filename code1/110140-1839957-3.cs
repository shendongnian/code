    public class QueryTranslatorProvider<T> : ExpressionTreeTranslator, IQueryProvider
    {
        IQueryable _source;
        public QueryTranslatorProvider(IQueryable source)
        {
            if (source == null) throw new ArgumentNullException("source");
            _source = source;
        }
        #region IQueryProvider Members
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (expression == null) throw new ArgumentNullException("expression");
            return new QueryTranslator<TElement>(_source, expression) as IQueryable<TElement>;
        }
        public IQueryable CreateQuery(Expression expression)
        {
            if (expression == null) throw new ArgumentNullException("expression");
            Type elementType = expression.Type.FindElementTypes().First();
            IQueryable result = (IQueryable)Activator.CreateInstance(typeof(QueryTranslator<>).MakeGenericType(elementType),
                new object[] { _source, expression });
            return result;
        }
        public TResult Execute<TResult>(Expression expression)
        {
            if (expression == null) throw new ArgumentNullException("expression");
            object result = (this as IQueryProvider).Execute(expression);
            return (TResult)result;
        }
        public object Execute(Expression expression)
        {
            if (expression == null) throw new ArgumentNullException("expression");
            
            Expression translated = this.Visit(expression);
            return _source.Provider.Execute(translated);            
        }
        internal IEnumerable ExecuteEnumerable(Expression expression)
        {
            if (expression == null) throw new ArgumentNullException("expression");
            
            Expression translated = this.Visit(expression);
            return _source.Provider.CreateQuery(translated);
        }
        #endregion        
        #region Visits
        protected override MethodCallExpression VisitMethodCall(MethodCallExpression m)
        {
            return m;
        }
        protected override Expression VisitUnary(UnaryExpression u)
        {
             return Expression.MakeUnary(u.NodeType, base.Visit(u.Operand), u.Type.ToImplementationType(), u.Method);
        }
        #endregion
    }
