    public object Call(object thisObject, object[] arguments)
    {
        var lexicalEnviroment = Scope.NewDeclarativeEnviroment();
        var variableEnviroment = Scope.NewDeclarativeEnviroment();
        var thisBinding = thisObject ?? Engine.GlobalEnviroment.GlobalObject;
        var newContext = new ExecutionContext(Engine, lexicalEnviroment, variableEnviroment, thisBinding);
        var result = default(object);
        var callArgs = default(object[]);
    
        Engine.EnterContext(newContext);
        while (true)
        {
            result = Function.Value(newContext, arguments);
            callArgs = result as object[];
            if (callArgs == null)
            {
                break;
            }
            for (int i = 0; i < callArgs.Length; i++)
            {
                callArgs[i] = Reference.GetValue(callArgs[i]);
            }
            arguments = callArgs;
        }
        Engine.LeaveContext();
    
        return result;
    }
