    public static class MethodUtils
    {
        public static string NameFromExpression(LambdaExpression expression)
        {
            MethodCallExpression callExpression = expression.Body as MethodCallExpression;
            if(callExpression == null)
            {                
                throw new Exception("expression must be a MethodCallExpression");
            }
            return callExpression.Method.Name;
        }
    }
