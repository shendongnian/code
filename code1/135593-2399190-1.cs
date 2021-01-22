    public IEnumerable<T> Get(Expression<Func<T, bool>> condition)
    {
        if (condition.Body.NodeType == ExpressionType.Equal)
        {
            var equalityExpression = ((BinaryExpression)condition.Body);
            var column = ((MemberExpression)equalityExpression.Left).Member.Name;
            var value = ((ConstantExpression)equalityExpression.Right).Value;
            var table = typeof(T).Name;
            var sql = string.Format("select * from {0} where {1} = '{2}'", table, column, value);
            return ExecuteSelect(sql);
        }
        return Enumerable.Empty<T>();
    }
