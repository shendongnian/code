    public static class PrivateSetterCaller
    {
        public static void SetPrivate<T,TValue>(this T instance, Expression<Func<T,TValue>> propertyExpression, TValue value)
        {
            instance.GetType().GetProperty(GetName(propertyExpression)).SetValue(instance, value, null);
        }
        private static string GetName<T, TValue>(Expression<Func<T, TValue>> exp)
        {
            MemberExpression body = exp.Body as MemberExpression;
            if (body == null)
            {
                UnaryExpression ubody = (UnaryExpression)exp.Body;
                body = ubody.Operand as MemberExpression;
            }
            return body.Member.Name;
        }
    }
