    public static Func<object[], object> CreateConstructorDelegate(ConstructorInfo method)
    {
            var args = Expression.Parameter(typeof(object[]), "args");
            var parameters = new List<Expression>();
            var methodParameters = method.GetParameters().ToList();
            for (var i = 0; i < methodParameters.Count; i++)
            {
                parameters.Add(Expression.Convert(
                                   Expression.ArrayIndex(args, Expression.Constant(i)),
                                   methodParameters[i].ParameterType));
            }
            var call = Expression.Convert(Expression.New(method, parameters), typeof(object));
            Expression body = call;
            var callExpression = Expression.Lambda<Func<object[], object>>(body, args);
            var result = callExpression.Compile();
            return result;
    }
