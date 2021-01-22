    internal static Expression RemoveConvert(Expression expression)
    {
        System.Diagnostics.Debug.Assert(expression != null);
        while ((expression != null)
                && (expression.NodeType == ExpressionType.Convert
                    || expression.NodeType == ExpressionType.ConvertChecked))
        {
            expression = RemoveConvert(((UnaryExpression)expression).Operand);
        }
        return expression;
    }
