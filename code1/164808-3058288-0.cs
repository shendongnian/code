    private readonly IDictionary<Expression, string> _cache
        = new Dictionary<Expression, string>(new ExpressionEqualityComparer());
    public string GenerateSomeSql(Expression<Func<TResult, TProperty>> expression)
    {
        string sql;
        if (!_cache.TryGetValue(expression, out sql))
        {
            //process expression
            _cache.Add(expression, sql);
        }
        return sql;
    }
    class ExpressionEqualityComparer : IEqualityComparer<Expression>
    {
        public bool Equals(Expression x, Expression y)
        {
            return ExpressionComparer.AreEqual(x, y);
        }
        public int GetHashCode(Expression obj)
        {
            return ExpressionHasher.GetHash(obj);
        }
    }
