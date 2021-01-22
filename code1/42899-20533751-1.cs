    //change signature to whatever that makes sense
    public static string GetMemberName(this LambdaExpression memberSelector)
    {
        var currentExpression = memberSelector.Body;
        while (true)
        {
            switch (currentExpression.NodeType)
            {
                case ExpressionType.Call:
                    return ((MethodCallExpression)currentExpression).Method.Name;
                case ExpressionType.MemberAccess:
                    return ((MemberExpression)currentExpression).Member.Name;
                case ExpressionType.Convert:
                    currentExpression = ((UnaryExpression)currentExpression).Operand;
                    break;
                case ExpressionType.Invoke:
                    currentExpression = ((InvocationExpression)currentExpression).Expression;
                    break;
                case ExpressionType.ArrayLength:
                    return "Length";
                default:
                    throw new Exception("not a proper member selector");
            }
        }
    }
