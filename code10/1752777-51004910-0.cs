    var containsMethod = typeof(string).GetMethod(nameof(string.Contains), new[] {typeof(string)});
    var predicate = Expression.Lambda<Func<Book, bool>>(
        Expression.Call(
            Expression.PropertyOrField(parameter, filterAfter)
        ,   containsMethod
        ,   new Expression[] { Expression.Constant(filterField) }
        )
    ,   parameter
    );
