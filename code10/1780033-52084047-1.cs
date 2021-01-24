    public static Expression<Func<TSource, TResult>> Compose<TSource, TIntermediate, TResult>(
        this Expression<Func<TSource, TIntermediate>> first,
        Expression<Func<TIntermediate, TResult>> second)
    {
        var param = Expression.Parameter(typeof(TSource));
        var intermediateValue = first.Body.ReplaceParameter(first.Parameters[0], param);
        var body = second.Body.ReplaceParameter(second.Parameters[0], intermediateValue);
        return Expression.Lambda<Func<TSource, TResult>>(body, param);
    }
    public static Expression ReplaceParameter(this Expression expression,
        ParameterExpression toReplace,
        Expression newExpression)
    {
        return new ParameterReplaceVisitor(toReplace, newExpression)
            .Visit(expression);
    }
    public class ParameterReplaceVisitor : ExpressionVisitor
    {
        private ParameterExpression from;
        private Expression to;
        public ParameterReplaceVisitor(ParameterExpression from, Expression to)
        {
            this.from = from;
            this.to = to;
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return node == from ? to : base.Visit(node);
        }
    }
