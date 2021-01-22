    public static class ExpressionExtesions
    {
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> baseCondition, Expression<Func<T, bool>> additionalCondition)
        {
            var and = Expression.AndAlso(baseCondition.Body, additionalCondition.Body);
            return Expression.Lambda<Func<T, bool>>(and, baseCondition.Parameters);  // additionalCondition.Body still uses its own parameters so this fails on Compile()
        }
    }
