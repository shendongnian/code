    Expression<Func<TModel, object>> GetPropertyExpression<TModel>(string propertyName) {
        // Manually build the expression tree for 
        // the lambda expression v => v.PropertyName.
        // (TModel v) =>
        var parameter = Expression.Parameter(typeof(TModel), "v");
        // v.PropertyName
        var property = Expression.Property(parameter, propertyName);
        // (TModel v) => v.PropertyName
        var expression = Expression.Lambda<Func<TModel, object>>(property, parameter);
        return expression;
    }
