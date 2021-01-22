    public static EnumerableImpl Stream<T>(this IQueryable<T> source)
    {
        var provider = ((NhQueryable<T>) source).Provider as DefaultQueryProvider;
        var sessionImpl = (ISessionImplementor)provider.GetType()
            .GetProperty("Session", BindingFlags.NonPublic | 
                BindingFlags.Instance).GetValue(provider);
        var expression = new NhLinqExpression(source.Expression, sessionImpl.Factory);
        var query = sessionImpl.CreateQuery(expression);
        query.SetParameters(expression.ParameterValuesByName);
        provider.SetResultTransformerAndAdditionalCriteria(
            query, expression, expression.ParameterValuesByName);
        return (EnumerableImpl)((AbstractQueryImpl2)query).Enumerable();
    }
    private static void SetParameters(this IQuery query, 
        IDictionary<string, Tuple<object, IType>> parameters)
    {
        foreach (var parameterName in query.NamedParameters)
        {
            var param = parameters[parameterName];
            if (param.Item1 == null)
            {
                if (typeof(IEnumerable).IsAssignableFrom(param.Item2.ReturnedClass) &&
                    param.Item2.ReturnedClass != typeof(string))
                    query.SetParameterList(parameterName, null, param.Item2);
                else query.SetParameter(parameterName, null, param.Item2);
            }
            else
            {
                if (param.Item1 is IEnumerable && !(param.Item1 is string))
                    query.SetParameterList(parameterName, (IEnumerable)param.Item1);
                else if (param.Item2 != null)
                    query.SetParameter(parameterName, param.Item1, param.Item2);
                else query.SetParameter(parameterName, param.Item1);
            }
        }
    }
