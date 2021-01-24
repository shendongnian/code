    class ReplaceParameterExpressionVisitor : ExpressionVisitor
    {
        private readonly Expression _target, _replacement;
    
        public ReplaceParameterExpressionVisitor(ParameterExpression target, Expression replacement)
        {
            _target = target;
            _replacement = replacement;
        }
    
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return node.Equals(_target) ? _replacement : node;
        }
    }
