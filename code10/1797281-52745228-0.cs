    protected class ParameterReplacer : ExpressionVisitor
    {
        private ParameterExpression parameterExpression;
        private string newValue;
    
        public ParameterReplacer(ParameterExpression parameterExpression, string newValue)
        {
            this.parameterExpression = parameterExpression;
            this.newValue = newValue;
        }
    
        public override Expression Visit(Expression node)
        {
            if (node == parameterExpression)
                return Expression.Constant(this.newValue);
    
            return base.Visit(node);
        }
    }
