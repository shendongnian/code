    public static PropertyInfo PropInfo<TContainer, TMember>(
        Expression<Func<TContainer, TMember>> memberGetter)
    {
        var memberName = GetExpressionMemberName(memberGetter);
        return typeof(TContainer).GetProperty(memberName);
    }
    
    public static string GetExpressionMemberName<TContainer, TMember>(
        Expression<Func<TContainer, TMember>> memberGetter)
    {
        var expressionType = memberGetter.Body.NodeType;
        switch (expressionType)
        {
            case ExpressionType.MemberAccess:
                {
                    var memberExpr = (MemberExpression) memberGetter.Body;
                    return memberExpr.Member.Name;
                }
            case ExpressionType.Convert:
                {
                    var convertExpr = (UnaryExpression) memberGetter.Body;
                    var memberExpr = (MemberExpression) convertExpr.Operand;
                    return memberExpr.Member.Name;
                }
            default:
                throw new InvalidOperationException("Expression {0} does not represent a simple member access.");
        }
    }
