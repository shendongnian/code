    public static Expression<Func<TInput, bool>> CreateFilterExpression<TInput>(
                                                       IEnumerable<Filter> filters)
    {
        ParameterExpression param = Expression.Parameter(typeof(TInput), "");
        Expression lambdaBody = null;
        if (filters != null)
        {
            foreach (Filter filter in filters)
            {
                Expression compareExpression = Expression.Equal(
                        Expression.Property(param, filter.FieldName),
                        Expression.Constant(filter.FilterString));
                if (lambdaBody == null)
                    lambdaBody = compareExpression;
                else
                    lambdaBody = Expression.Or(lambdaBody, compareExpression);
            }
        }
        if (lambdaBody == null)
            return Expression.Lambda<Func<TInput, bool>>(Expression.Constant(false));
        else
            return Expression.Lambda<Func<TInput, bool>>(lambdaBody, param);
    }
