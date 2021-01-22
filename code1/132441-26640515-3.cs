    static Expression<Func<A, C>> Compose<A, B, C>(Expression<Func<B, C>> f,
                                                   Expression<Func<A, B>> g)
    {
        var ex = ReplaceExpressions(f.Body, f.Parameters[0], g.Body);
        return Expression.Lambda<Func<A, C>>(ex, g.Parameters[0]);
    }
    static TExpr ReplaceExpressions<TExpr>(TExpr expression,
                                           Expression orig,
                                           Expression replacement)
        where TExpr : Expression 
    {
        var replacer = new ExpressionReplacer(orig, replacement);
        return replacer.VisitAndConvert(expression, nameof(ReplaceExpressions));
    }
    private class ExpressionReplacer : ExpressionVisitor
    {
        private readonly Expression From;
        private readonly Expression To;
        public ExpressionReplacer(Expression from, Expression to)
        {
            From = from;
            To = to;
        }
        public override Expression Visit(Expression node)
        {
            return node == From ? To : base.Visit(node);
        }
    }
