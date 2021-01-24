    public class AnyMethodArgumentReplacingVisitor : ExpressionVisitor
    {
        private readonly Expression expression;
    
        public AnyMethodArgumentReplacingVisitor(Expression expression)
        {
            this.expression = expression;
        }
    
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.Name == "Any")
            {
                return Expression.Call(node.Object, node.Method, node.Arguments[0], expression);
            }
    
            return base.VisitMethodCall(node);
        }
    }
