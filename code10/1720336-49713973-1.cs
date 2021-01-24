    public static class ExpressionExtensions
    {
        public static Expression<Func<T, R>> ReplaceParameter<T, R, U>(this Expression<Func<U, R>> origin, Expression<Func<T, U>> accessor)
        {
            var originalParameter = origin.Parameters.Single();
            var replacement = accessor.Body;
            var visitor = new ReplaceParameterExpressionVisitor(originalParameter, replacement);
            var newBody = visitor.Visit(origin.Body);
            return Expression.Lambda<Func<T, R>>(newBody, accessor.Parameters.Single());
        }
    }
