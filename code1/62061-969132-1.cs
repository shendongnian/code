    using (DataContext ctx = new DataClasses1DataContext())
    {
        Console.WriteLine(ctx.Any<Customer, string>("CompanyName", "none-such"));
        Console.WriteLine(ctx.Any<Customer, string>("CompanyName", knownName));
    }
    ...
    static bool Any<TEntity, TValue>(
        this DataContext ctx,
        string propertyOrFieldName,
        TValue value)
        where TEntity : class
    {
        var param = Expression.Parameter(typeof(TEntity), "row");
        var lambda =
            Expression.Lambda<Func<TEntity, bool>>(
                Expression.Equal(
                    Expression.PropertyOrField(param, propertyOrFieldName),
                    Expression.Constant(value, typeof(TValue))),
                    param);
        return ctx.GetTable<TEntity>().Any(lambda);
    }
