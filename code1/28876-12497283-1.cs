    internal class SubstExpressionVisitor : System.Linq.Expressions.ExpressionVisitor {
            public Dictionary<Expression, Expression> subst = new Dictionary<Expression, Expression>();
    
            protected override Expression VisitParameter(ParameterExpression node) {
                Expression newValue;
                if (subst.TryGetValue(node, out newValue)) {
                    return newValue;
                }
                return node;
            }
        }
    
