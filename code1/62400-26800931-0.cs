     public static IQueryable<T> WhereIn<T,TProp>(this IQueryable<T> source, Expression<Func<T,TProp>> memberExpr, IEnumerable<TProp> values) where T : class
        {
            Expression predicate = null;
            ParameterExpression param = Expression.Parameter(typeof(T), "t");
    
            bool IsFirst = true;
    
            MemberExpression me = (MemberExpression) memberExpr.Body;
            foreach (TProp val in values)
            {
                ConstantExpression ce = Expression.Constant(val);
    
    
                Expression comparison = Expression.Equal(me, ce);
    
                if (IsFirst)
                {
                    predicate = comparison;
                    IsFirst = false;
                }
                else
                {
                    predicate = Expression.Or(predicate, comparison);
                }
            }
    
            return predicate != null
                ? source.Where(Expression.Lambda<Func<T, bool>>(predicate, param)).AsQueryable<T>()
                : source;
        }
