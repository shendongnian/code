    // Type: System.Linq.Queryable
    // Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
    // Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Core.dll
    public static class Queryable
    {
        public static IQueryable<TSource> Where<TSource>(
            this IQueryable<TSource> source, 
            Expression<Func<TSource, bool>> predicate)
        {
            return source.Provider.CreateQuery<TSource>(
                Expression.Call(
                    null, 
                    ((MethodInfo) MethodBase.GetCurrentMethod()).MakeGenericMethod(
                        new Type[] { typeof(TSource) }), 
                        new Expression[] 
                            { source.Expression, Expression.Quote(predicate) }));
        }
    }
