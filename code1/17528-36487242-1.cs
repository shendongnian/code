    public static class Helpers
    {
        public static string PropertyName<T>(Expression<Func<T>> expression)
        {
            var member = expression.Body as MemberExpression;
            if (member != null && member.Member is PropertyInfo)
                return member.Member.Name;
            throw new ArgumentException("Expression is not a Property", "expression");
        }
    }
