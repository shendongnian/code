    public static IQueryable GroupByComplete( this IQueryable source, string keySelector, params object[] values )
    {
        if (source == null) throw new ArgumentNullException( "source" );
        if (keySelector == null) throw new ArgumentNullException( "keySelector" );
        LambdaExpression keyLambda = DynamicExpression.ParseLambda( source.ElementType, null, keySelector, values );
        return source.Provider.CreateQuery(
            Expression.Call(
                typeof( Queryable ), "GroupBy",
                new Type[] { source.ElementType, keyLambda.Body.Type },
                source.Expression, Expression.Quote( keyLambda ) ) );
    }
