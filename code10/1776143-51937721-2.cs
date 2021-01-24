    public static class ActionNameExtensions<TController>
    {
        public static string FindActionName<T>(Expression<Func<TController, T>> expression)
        {
            MethodCallExpression outermostExpression = expression.Body as MethodCallExpression;
            
            if (outermostExpression == null)
            {
                throw new ArgumentException("Not a " + nameof(MethodCallExpression));
            }
            return outermostExpression.Method.GetCustomAttribute<ActionNameAttribute>().Name;
        }
    }
