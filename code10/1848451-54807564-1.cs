    internal class ReplaceExpressionVisitor : ExpressionVisitor
    {
        private readonly Expression oldValue;
        private readonly Expression newValue;
        public ReplaceExpressionVisitor(ParameterExpression oldValue,
                                        ParameterExpression newValue)
        {
            this.oldValue = oldValue;
            this.newValue = newValue;
        }
        public override Expression Visit(Expression node)
        {
            if (node == this.oldValue)
			{   // "my" expression is visited
                return this.newValue;
            }
            else
            {   // not my Expression, I don't know how to Visit it, let the base class handle this
                return base.Visit(node);
            }
        }
    }
