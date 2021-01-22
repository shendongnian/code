    public static IQueryable OrderBy(this IQueryable source, 
                                          string ordering, 
                                          params object[] values) {
        if (source == null) throw new ArgumentNullException("source");
        if (ordering == null) throw new ArgumentNullException("ordering");
        ParameterExpression[] parameters = new ParameterExpression[] {
            Expression.Parameter(source.ElementType, "") };
        ExpressionParser parser = new ExpressionParser(parameters, 
                                                       ordering, 
                                                       values);
        IEnumerable<DynamicOrdering> orderings = parser.ParseOrdering();
        Expression queryExpr = source.Expression;
        string methodAsc = "OrderBy";
        string methodDesc = "OrderByDescending";
        foreach (DynamicOrdering o in orderings) {
            queryExpr = Expression.Call(
                typeof(Queryable), o.Ascending ? methodAsc : methodDesc,
                new Type[] { source.ElementType, o.Selector.Type },
                queryExpr, Expression.Quote(Expression.Lambda(o.Selector, 
                                                              parameters)));
            methodAsc = "ThenBy";
            methodDesc = "ThenByDescending";
        }
        return source.Provider.CreateQuery(queryExpr);
    }
