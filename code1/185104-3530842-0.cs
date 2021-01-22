    Expression<Func<Foo, bool>> IsSuperhuman = x => x.CanFly && x.HasXRayVision;
    
    Expression<Func<Foo, bool>> IsSuperheroine = AndAlso(IsSuperhuman, x => x.IsFemale);
    ...
    public static Expression<Func<T, TResult>> AndAlso<T, TResult>(Expression<Func<T, TResult>> expr1, Expression<Func<T, TResult>> expr2)
    {
        var arg = Expression.Parameter(typeof(T), expr1.Parameters[0].Name);
        var andExpr = Expression.AndAlso(
            ReplaceParameter(expr1.Body, expr1.Parameters[0], arg),
            ReplaceParameter(expr2.Body, expr2.Parameters[0], arg));
        return Expression.Lambda<Func<T, TResult>>(andExpr, arg);
    }
    
    public static Expression ReplaceParameter(Expression expr, ParameterExpression oldParam, ParameterExpression newParam)
    {
        return new ReplaceParameterVisitor(oldParam, newParam).Visit(expr);
    }
    
    internal class ReplaceParameterVisitor : ExpressionVisitor
    {
        private ParameterExpression _oldParam;
        private ParameterExpression _newParam;
    
        public ReplaceParameterVisitor(ParameterExpression oldParam, ParameterExpression newParam)
        {
            _oldParam = oldParam;
            _newParam = newParam;
        }
        
        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (node == _oldParam)
                return _newParam;
            return node;
        }
    }
