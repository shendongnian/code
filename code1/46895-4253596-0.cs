    public static Expression<Func<TModel, TToProperty>> Cast<TModel, TFromProperty, TToProperty>(Expression<Func<TModel, TFromProperty>> expression)
    {
        Expression converted = Expression.Convert(expression.Body, typeof(TToProperty));
        return Expression.Lambda<Func<TModel, TToProperty>>(converted, expression.Parameters);
    }
