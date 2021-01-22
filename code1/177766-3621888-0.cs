    public static class ExpressionsExtractor
    {
        public static string GetMemberName<TObj, TProp>(Expression<Func<TObj, TProp>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
                return null;
            return memberExpression.Member.Name;
        }
    }
