    public static class ObjectExtensions
    {
        public static string PropertyName<T,TOut>(this T source, Expression<Func<T,TOut>> property)
        {
            var memberExpression = (MemberExpression) property.Body;
            return memberExpression.Member.Name;
        }
    }
