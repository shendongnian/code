    public static class ExpressionHelpers
    {
        public static Expression<Func<TArg2, TReturn>> ReplaceParamter<TArg1, TArg2, TReturn>(this Expression<Func<TArg1, TArg2, TReturn>> source, TArg1 arg1)
        {
            var t1Param = Expression.Constant(arg1);
            var t2Param = Expression.Parameter(typeof(TArg2));
            var body = source.Body
                        .ReplaceParameter(source.Parameters[0], t1Param)
                        .ReplaceParameter(source.Parameters[1], t2Param);
            return Expression.Lambda<Func<TArg2, TReturn>>(body, t2Param);
        }
        public static Expression<Func<TArg1, TReturn>> ReplaceParamter<TArg1, TArg2, TReturn>(this Expression<Func<TArg1, TArg2, TReturn>> source, TArg2 arg2)
        {
            var t1Param = Expression.Parameter(typeof(TArg1));
            var t2Param = Expression.Constant(arg2);
            var body = source.Body
                        .ReplaceParameter(source.Parameters[0], t1Param)
                        .ReplaceParameter(source.Parameters[1], t2Param);
            return Expression.Lambda<Func<TArg1, TReturn>>(body, t1Param);
        }
        public static Expression ReplaceParameter(this Expression expression,
            ParameterExpression toReplace,
            Expression newExpression)
        {
            return new ParameterReplaceVisitor(toReplace, newExpression)
                .Visit(expression);
        }
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
            return node == from ? to : base.VisitParameter(node);
        }
    }
