    // Or IEnumerable<SortColumn> columns
    public static Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> GetOrderByFunction<TEntity>(params SortColumn[] columns)
    {
        Type typeQueryable = typeof(IQueryable<TEntity>);
        ParameterExpression argQueryable = Expression.Parameter(typeQueryable, "p");
        Type entityType = typeof(TEntity);
        ParameterExpression arg = Expression.Parameter(entityType, "x");
        Expression resultExp = argQueryable;
        bool first = true;
        foreach (SortColumn sc in columns)
        {
            PropertyInfo pi = entityType.GetProperty(sc.FieldName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            Expression propertyExpr = Expression.Property(arg, pi);
            Type propertyType = pi.PropertyType;
            LambdaExpression lambdaExp = Expression.Lambda(propertyExpr, arg);
            string methodName;
            if (first)
            {
                first = false;
                methodName = sc.Descending ? "OrderBy" : "OrderByDescending";
            }
            else
            {
                methodName = sc.Descending ? "ThenBy" : "ThenByDescending";
            }
            resultExp = Expression.Call(typeof(Queryable), methodName, new Type[] { entityType, propertyType }, resultExp, Expression.Quote(lambdaExp));
        }
        // Case empty columns: simply append a .OrderBy(x => true)
        if (first)
        {
            LambdaExpression lambdaExp = Expression.Lambda(Expression.Constant(true), arg);
            resultExp = Expression.Call(typeof(Queryable), "OrderBy", new Type[] { entityType, typeof(bool) }, resultExp, Expression.Quote(lambdaExp));
        }
        LambdaExpression orderedLambda = Expression.Lambda(resultExp, argQueryable);
        return (Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>)orderedLambda.Compile();
    }
