    protected override Expression VisitBinary(BinaryExpression node)
    {
        var visited = base.VisitBinary(node);
        
        if(visited is BinaryExpression be
            && be.Method == null && be.Conversion == null
            && !be.IsLifted
            && be.Left is ConstantExpression left
            && be.Right is ConstantExpression right)
        {
            object val;
            switch(be.NodeType)
            {
                case ExpressionType.Add:
                    val = (dynamic)left.Value + (dynamic)right.Value;
                    break;
                case ExpressionType.Multiply:
                    val = (dynamic)left.Value * (dynamic)right.Value;
                    break;
                case ExpressionType.Subtract:
                    val = (dynamic)left.Value - (dynamic)right.Value;
                    break;
                case ExpressionType.Divide:
                    val = (dynamic)left.Value / (dynamic)right.Value;
                    break;
                default:
                    return visited; // unknown
            }
            return Expression.Constant(
                Convert.ChangeType(val, visited.Type), visited.Type);
        }
        return visited;
    }
