     public static class Util
    {
        public static void Print<T>(Expression<Func<T>> expr)
        {
            WriteExpression(expr);
        }
        public static void Print(Expression<Action> expr) // for "void" methods
        {
            WriteExpression(expr);
        }
        private static void WriteExpression(Expression expr)
        {
            LambdaExpression lambda = (LambdaExpression)expr;
            switch (lambda.Body.NodeType)
            {
                case ExpressionType.MemberAccess:
                    Console.WriteLine(((MemberExpression)lambda.Body)
                        .Member.Name);
                    break;
                case ExpressionType.Call:
                    Console.WriteLine(((MethodCallExpression)lambda.Body)
                        .Method.Name);
                    break;
                default:
                    throw new NotSupportedException();
            }
        }
    }
