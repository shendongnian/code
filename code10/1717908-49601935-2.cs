    public static IQueryable<TSource> In<TSource, TMember>(this IQueryable<TSource> source,
       Expression<Func<TSource, TMember>> identifier, params TMember[] values)
            {
                var parameter = Expression.Parameter(typeof(TSource), "m");
                var inExpression = GetExpression(parameter, identifier, values);
                var theExpression = Expression.Lambda<Func<TSource, bool>>(inExpression, parameter);
                return source.Where(theExpression);
            }
    static Expression GetExpression<TSource, TMember>(ParameterExpression parameter, Expression<Func<TSource, TMember>> identifier, IEnumerable<TMember> values)
            {
                var memberName = (identifier.Body as MemberExpression).Member.Name;
                var member = Expression.Property(parameter, memberName);
                var valuesConstant = Expression.Constant(values.ToList());
                MethodInfo method = typeof(List<TMember>).GetMethod("Contains");
                Expression call = Expression.Call(valuesConstant, method, member);
                return call;
            }
