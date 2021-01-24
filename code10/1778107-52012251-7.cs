    private static CommandInvoker CreateCommandInvoker(MethodInfo method)
    {
        var configureParam = Expression.Parameter(typeof(Action<CommandContext>));
        var commandContextVar = Expression.Variable(method.DeclaringType);
        var bodyBlock = Expression.Block(new[] { commandContextVar }, new Expression[]
        {
            Expression.Assign(commandContextVar, Expression.New(method.DeclaringType)),
            Expression.Invoke(configureParam, commandContextVar),
            Expression.Call(commandContextVar, method),
        });
        var lambda = Expression.Lambda<CommandInvoker>(bodyBlock, configureParam);
        return lambda.Compile();
    }
