    // OrderBy method has generic parameters and several overloads. It is thus 
    // difficult to get it's MethodInfo just by typeof(Queryable).GetMethod().
    // Although it may seem weird, but it is easier to get it's MethodInfo from
    // some arbitrary expression. Generic arguments "<object, object>" does not
    // matter for now, we will replace them later
    Expression<Func<IQueryable<object>, IQueryable<object>>> orderByExpression =
        x => x.OrderBy<object, object>((o) => null);
    // Replace generic parameters of OrderBy method with actual generic arguments
    var orderByMethodInfo = (orderByExpression.Body as MethodCallExpression)
        .Method
        .GetGenericMethodDefinition()
        .MakeGenericMethod(new[] { typeof(T), keyType });
    // Now we are finally ready to call OrderBy method
    var orderedResultQuery = orderByMethodInfo.Invoke(
        null,
        new Object[] { myQueryable, lambda })
        as IQueryable<T>;
    // Just for testing purpose, let's materialize result to list
    var orderedResult = orderedResultQuery.ToList();
