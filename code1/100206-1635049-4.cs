    internal class ListPrintVisitor : ExpressionVisitor
    {
        protected override Expression VisitBinary(BinaryExpression node)
        {
            string op = null;
            switch (node.NodeType)
            {
            case ExpressionType.Add:
                op = "+";
                break;
            case ExpressionType.Subtract:
                op = "-";
                break;
            case ExpressionType.Multiply:
                op = "*";
                break;
            case ExpressionType.Divide:
                op = "/";
                break;
            default:
                throw new NotImplementedException();
            }
            var left = Visit(node.Left);
            var right = Visit(node.Right);
            string result = string.Format("({0} {1} {2})", op, ((ConstantExpression)left).Value, ((ConstantExpression)right).Value);
            return Expression.Constant(result);
        }
        protected override Expression VisitConstant(ConstantExpression node)
        {
            if (node.Value is string)
                return node;
            return Expression.Constant(node.Value.ToString());
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return Expression.Constant(node.Name);
        }
    }
