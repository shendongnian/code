    public static class AllFieldsEqualityComprision<T>
    {
        public static Comparison<T> Instance { get; } = GetInstance();
        private static Comparison<T> GetInstance()
        {
            var type = typeof(T);
            ParameterExpression[] parameters =
            {
                Expression.Parameter(type, "x"),
                Expression.Parameter(type, "y")
            };
            var result = type.GetProperties().Aggregate<PropertyInfo, Expression>(
                Expression.Constant(true),
                (acc, prop) =>
                    Expression.And(acc,
                        Expression.Equal(
                            Expression.Property(parameters[0], prop.Name),
                            Expression.Property(parameters[1], prop.Name))));
            var areEqualExpression = Expression.Condition(result, Expression.Constant(0), Expression.Constant(1));
            return Expression.Lambda<Comparison<T>>(areEqualExpression, parameters).Compile();
        }
    }
