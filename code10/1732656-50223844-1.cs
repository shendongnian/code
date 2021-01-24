    public class CustomExpressionVisitor : ExpressionVisitor
    {
        protected override Expression VisitNew(NewExpression node)
        {
            Console.WriteLine($"{node.Members?.First().Name} {node.Arguments.FirstOrDefault()}");
            return base.VisitNew(node);
        }
    }
