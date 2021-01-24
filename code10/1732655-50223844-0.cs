    public class CustomExpressionVisitor : ExpressionVisitor
    {
        protected override Expression VisitNew(NewExpression node)
        {
            Console.WriteLine($"{node.Members.First().Name} {node.Arguments.First()}");
            return base.VisitNew(node);
        }
    }
