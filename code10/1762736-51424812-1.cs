    // x =>
    var parameter = Expression.Parameter(typeof(T));
    // x.Name
    var mapProperty = Expression.Property(parameter, "Name");
    // (object)x.Name
    var convertedExpression = Expression.Convert(mapProperty, typeof(object));
    // x => (object)x.Name
    var exp = Expression.Lambda<Func<T, object>>(convertedExpression, parameter);
