    class ParameterReplacer : ExpressionVisitor
    {
        private readonly ParameterExpression[] parameter;
        internal ParameterReplacer(params ParameterExpression[] parameter)
        {
            this.parameter = parameter;
        }
        protected override Expression VisitParameter
            (ParameterExpression node)
        {
            return parameter.Single(x => x.Type == node.Type);
        }
    }
