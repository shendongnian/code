        public static IEnumerable<Func<T, object>> GetTypeGetters<T>()
        {
            var fields = typeof (T).GetFields();
            foreach (var field in fields)
            {
                ParameterExpression targetExp = Expression.Parameter(typeof(T), "target");
                UnaryExpression boxedFieldExp = Expression.Convert(Expression.Field(targetExp, field), typeof(object));
                yield return  Expression.Lambda<Func<T,object>>(boxedFieldExp, targetExp).Compile();
            }
        }
