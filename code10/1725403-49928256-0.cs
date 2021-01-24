    public class EmbedVisitor : ExpressionVisitor {
        public override Expression Visit(Expression node) {
            if (node?.NodeType == ExpressionType.Call) {
                var callnode = node as MethodCallExpression;
                if (callnode.Method.Name == "Embed" && callnode.Method.DeclaringType == typeof(ExpressionExt))
                    return callnode.Arguments[0].Evaluate<Expression>();
            }
    
            return base.Visit(node);
        }
    }
