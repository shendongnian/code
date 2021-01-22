    public static class Extensions
    {
        private static readonly MethodInfo OrderByMethod = typeof(Queryable).GetMethods()
                                                            .Where(method => method.Name == "OrderBy")
                                                            .Where(method => method.GetParameters().Length == 2)
                                                            .Single();
        private static readonly MethodInfo OrderByDescMethod = typeof(Queryable).GetMethods()
                                                                .Where(method => method.Name == "OrderByDescending")
                                                                .Where(method => method.GetParameters().Length == 2)
                                                                .Single();
        private static readonly MethodInfo ThenByMethod = typeof(Queryable).GetMethods()
                                                        .Where(method => method.Name == "ThenBy")
                                                        .Where(method => method.GetParameters().Length == 2)
                                                        .Single();
        private static readonly MethodInfo ThenByDescMethod = typeof(Queryable).GetMethods()
                                                        .Where(method => method.Name == "ThenByDescending")
                                                        .Where(method => method.GetParameters().Length == 2)
                                                        .Single();
        internal static IQueryable<T> OrderBy<T>(this IQueryable<T> sourceQuery, List<DynamicSortExpression<T>> orderBy)
        {
            bool isFirst = true;
            foreach (var sortExpression in orderBy)
            {
                if (isFirst)
                {
                    sourceQuery = sourceQuery.OrderByDynamic(sortExpression);
                    isFirst = false;
                }
                else
                    sourceQuery = sourceQuery.ThenByDynamic(sortExpression);
            }
            return sourceQuery;
        }
        internal static IQueryable<T> OrderByDynamic<T>(this IQueryable<T> source, DynamicSortExpression<T> sortExpression)
        {
            //We need to convert the key selector from Expression<Func<T, object>> to a strongly typed Expression<Func<T, TKey>>
            //in order for Entity Framework to be able to translate it to SQL
            MemberExpression orderByMemExp = ExpressionHelpers.RemoveConvert(sortExpression.KeySelector.Body) as MemberExpression;
            ParameterExpression sourceParam = sortExpression.KeySelector.Parameters[0];
            LambdaExpression orderByLamda = Expression.Lambda(orderByMemExp, new[] { sourceParam });
            MethodInfo orderByMethod = sortExpression.Desc ?
                                            OrderByDescMethod.MakeGenericMethod(new[] { typeof(T), orderByMemExp.Type }) :
                                            OrderByMethod.MakeGenericMethod(new[] { typeof(T), orderByMemExp.Type });
            //Call OrderBy or OrderByDescending on the source IQueryable<T>
            return (IQueryable<T>)orderByMethod.Invoke(null, new object[] { source, orderByLamda });
        }
        internal static IQueryable<T> ThenByDynamic<T>(this IQueryable<T> source, DynamicSortExpression<T> sortExpression)
        {
            //We need to convert the key selector from Expression<Func<T, object>> to a strongly typed Expression<Func<T, TKey>>
            //in order for Entity Framework to be able to translate it to SQL
            Expression orderByMemExp = ExpressionHelpers.RemoveConvert(sortExpression.KeySelector.Body) as MemberExpression;
            ParameterExpression sourceParam = sortExpression.KeySelector.Parameters[0];
            LambdaExpression orderByLamda = Expression.Lambda(orderByMemExp, new[] { sourceParam });
            MethodInfo orderByMethod = sortExpression.Desc ?
                                            ThenByDescMethod.MakeGenericMethod(new[] { typeof(T), orderByMemExp.Type }) :
                                            ThenByMethod.MakeGenericMethod(new[] { typeof(T), orderByMemExp.Type });
            //Call OrderBy or OrderByDescending on the source IQueryable<T>
            return (IQueryable<T>)orderByMethod.Invoke(null, new object[] { source, orderByLamda });
        }
    }
