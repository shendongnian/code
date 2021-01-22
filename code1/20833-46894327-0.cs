    public static class AllFieldsComprision<T>
    {
        public static Comparison<T> Instance { get; } = GetInstance();
        private static Comparison<T> GetInstance()
        {
            var type = typeof(T);
            ParameterExpression[] Parameters =
            {
                Expression.Parameter(type, "x"),
                Expression.Parameter(type, "y")
            };
            var result = type.GetProperties().Aggregate<PropertyInfo, Expression>(Expression.Constant(true), (acc, prop) => Expression.And(acc, Expression.Equal(Expression.Property(Parameters[0], prop.Name), Expression.Property(Parameters[1], prop.Name))));
            return Expression.Lambda<Comparison<T>>(Expression.Condition(result, Expression.Constant(0), Expression.Constant(1)), Parameters)
                .Compile();
        }
    }
