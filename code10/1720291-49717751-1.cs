    var parameters = handlerInfo.GetParameters();
    // expression of type ICommand
    var expressionArg = Expression.Parameter(typeof(ICommand), "x");
    // this is handlerInfo.HandleA((CommandA) x)
    var callExp = Expression.Call(Expression.Constant(handlerGroup), handlerInfo, Expression.Convert(expressionArg, parameters.Single().ParameterType));
    // this is delegate x => handlerInfo.HandleA((CommandA) x)
    var handler = Expression.Lambda<HandlerDelegate>(callExp, new[] { expressionArg }).Compile();                    
    cache.Add(parameters.Single().ParameterType, handler);
