    public static T CheckedGet<T>(Expression<Func<T>> expr) where T : class
    {
        CheckAccess(expr);
        return expr.Compile().Invoke();
    }
    public static void CheckAccess(Expression expr)
    {
        switch (expr.NodeType)
        {
            case ExpressionType.Lambda:
                CheckAccess((expr as LambdaExpression).Body);
                break;
            case ExpressionType.MemberAccess:
                {
                    CheckAccess((expr as MemberExpression).Expression);
                    var value = Expression.Lambda(expr).Compile().DynamicInvoke();
                    if (value == null)
                    {
                        throw new NullReferenceException(expr.ToString());
                    }
                }
                break;
            case ExpressionType.ArrayIndex:
                {
                    var binaryExpr = expr as BinaryExpression;
                    CheckAccess(binaryExpr.Left);
                    var arrayLength = (int)Expression.Lambda(Expression.ArrayLength(binaryExpr.Left)).Compile().DynamicInvoke();
                    var arrayIndex = (int)Expression.Lambda(binaryExpr.Right).Compile().DynamicInvoke();
                    if (arrayIndex >= arrayLength)
                    {
                        throw new IndexOutOfRangeException(expr.ToString());
                    }
                    var value = Expression.Lambda(expr).Compile().DynamicInvoke();
                    if (value == null)
                    {
                        throw new NullReferenceException(expr.ToString());
                    }
                }
                break;
            case ExpressionType.Constant:
                return;
        }
    }
