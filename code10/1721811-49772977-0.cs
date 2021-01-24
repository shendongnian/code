    var orderByCallExpression = Expression.Call(
        typeof(Queryable),
        method,
        new Type[] { source.ElementType, orderByExpression.Body.Type }, // <--
        whereCallExpression,
        Expression.Quote(orderByExpression));
