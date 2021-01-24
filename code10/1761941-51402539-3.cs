    public static IQueryable<TSource> Except<TSource>(this IQueryable<TSource> source1, IEnumerable<TSource> source2) {
                if (source1 == null)
                    throw Error.ArgumentNull("source1");
                if (source2 == null)
                    throw Error.ArgumentNull("source2");
                return source1.Provider.CreateQuery<TSource>( 
                    Expression.Call(
                        null, 
                        GetMethodInfo(Queryable.Except, source1, source2),
                        new Expression[] { source1.Expression, GetSourceExpression(source2) }
                        ));
            }
