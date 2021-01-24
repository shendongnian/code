    public static class ExpressionHelper
    {
        public static Expression<Func<TModel, TProperty>> CreateMemberExpression<TModel, TProperty>(PropertyInfo propertyInfo)
        {
            if (propertyInfo == null)
                throw new ArgumentException("Argument cannot be null", "propertyInfo");
            ParameterExpression entityParam = Expression.Parameter(typeof(TModel), "x");
            Expression columnExpr = Expression.Property(entityParam, propertyInfo);
            if (propertyInfo.PropertyType != typeof(T))
                columnExpr = Expression.Convert(columnExpr, typeof(T));
            return Expression.Lambda<Func<TModel, TProperty>>(columnExpr, entityParam);
        }
        public static object CreateMemberExpressionForProperty<TModel>(PropertyInfo property)
        {
            MethodInfo methodInfo = typeof(ExpressionHelper).GetMethod("CreateMemberExpression", BindingFlags.Static | BindingFlags.Public);
            Type[] argumentTypes = new Type[] { typeof(TModel), property.PropertyType };
            MethodInfo genericMethod = methodInfo.MakeGenericMethod(argumentTypes);
            return genericMethod.Invoke(null, new object[] { property });
        }
    }
