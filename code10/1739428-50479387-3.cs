    //Creates x=>x.Something == value
    public Expression<Func<T, bool>> EqualCriteria<T>(string propertyName, object value)
    {
        var property = typeof(T).GetProperty(propertyName);
        var x = Expression.Parameter(typeof(T), "x");
        var propertyExpression = Expression.Property(x, property.Name);
        var valueExpression = Expression.Convert(Expression.Constant(value),
            property.PropertyType);
        var criteria = Expression.Equal(propertyExpression, valueExpression);
        var lambda = Expression.Lambda<Func<T, bool>>(criteria, x);
        return lambda;
    }
