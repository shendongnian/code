    static void Main()
    {
        string knownName;
        using (DataClasses1DataContext ctx = new DataClasses1DataContext())
        {
            knownName = ctx.Customers.First().CompanyName;
        }
        using (DataContext ctx = new DataClasses1DataContext())
        {
            Console.WriteLine(ctx.Any<Customer, string>(
                 cust => cust.CompanyName, "none-such"));
            Console.WriteLine(ctx.Any<Customer, string>(
                 cust => cust.CompanyName, knownName));
        }
    }
    static bool Any<TEntity, TValue>(
        this DataContext ctx,
        Expression<Func<TEntity, TValue>> selector,
        TValue value)
        where TEntity : class
    {
        var lambda =
            Expression.Lambda<Func<TEntity, bool>>(
                Expression.Equal(
                    selector.Body,
                    Expression.Constant(value, typeof(TValue))),
                    selector.Parameters);
        return ctx.GetTable<TEntity>().Any(lambda);
    }
