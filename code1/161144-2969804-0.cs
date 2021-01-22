    public static class ExpressionHelper
    {
        public static MemberExpression PropertyExpression(this Expression expr,string propertyName)
        {           
            var properties = propertyName.Split('.');
            MemberExpression expression = null;
            foreach (var property in properties)
            {
                if (expression == null)
                    expression = Expression.Property(expr, property);
                else
                    expression = Expression.Property(expression, property);
            }
            return expression;
        }
        public static BinaryExpression EqualExpression<T>(this Expression expr, string propertyName, T value)
        {
            return Expression.Equal(expr.PropertyExpression(propertyName), Expression.Constant(value, typeof(T)));
        }
    }
