    public static class ExpressionHelper
    {
        public static Expression<Func<TSource, TResult>> TryDefaultExpression<TSource, TResult>(Expression<Func<TSource, TResult>> success, TResult defaultValue)
        {
            var body = Expression.TryCatch(success.Body, Expression.Catch(Expression.Parameter(typeof(Exception)), Expression.Constant(defaultValue, typeof (TResult))));
            var lambda = Expression.Lambda<Func<TSource, TResult>>(body, success.Parameters);
    
            return lambda;
        }
    }
