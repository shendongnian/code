    public static class Util
    {
        public static void Print<T>(Expression<Func<T>> expr)
        {
            LambdaExpression lambda = (LambdaExpression)expr;
            switch (lambda.Body.NodeType)
            {
                case ExpressionType.MemberAccess:
                    Console.WriteLine(((MemberExpression)lambda.Body)
                        .Member.Name);
                    break;
                default:
                    throw new NotSupportedException();
            }
        }
    }
