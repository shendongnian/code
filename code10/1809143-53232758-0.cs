    if (!(expression.Body is MemberExpression))
    {
        if (expression.Body is UnaryExpression unaryExpression && unaryExpression.NodeType == ExpressionType.Convert)
            expression = unaryExpression.Operand as MemberExpression;
        else
            expression = null;
        if (expression == null)
            throw new ArgumentException("something happened");
    }
