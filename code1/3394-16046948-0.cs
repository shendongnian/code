    public static IEnumerable<TEntity> OrderBy<TEntity>(this IEnumerable<TEntity> source, string orderByProperty,
                                bool desc)
            {
                string command = desc ? "OrderByDescending" : "OrderBy";
                var type = typeof(TEntity);
                var property = type.GetProperty(orderByProperty);
                var parameter = Expression.Parameter(type, "p");
                var propertyAccess = Expression.MakeMemberAccess(parameter, property);
                var orderByExpression = Expression.Lambda(propertyAccess, parameter);
                var resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { type, property.PropertyType },
                                              source.AsQueryable().Expression, Expression.Quote(orderByExpression));
                return source.AsQueryable().Provider.CreateQuery<TEntity>(resultExpression);
            }
