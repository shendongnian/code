    public static class ExpressionExtensions
    {
        public static Expression<Func<U, R>> RewriteParameter<T, U, R>(this Expression<Func<T, R>> expression)
        {
            var rewriter = new ParameterRewriter<T, U>();
            return (Expression<Func<U, R>>)rewriter.Visit(expression);
        }
    }
