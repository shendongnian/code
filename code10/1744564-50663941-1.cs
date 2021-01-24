    static Action<object, object> MakeFunc(EventInfo sourceEvent, MethodInfo targetMethod)
    {
        // setting up objects involved
        var sourceParam = Expression.Parameter(typeof(object), "source");
        var targetParam = Expression.Parameter(typeof(object), "target");
        var sourceParamCast = Expression.Convert(sourceParam, sourceEvent.DeclaringType);
        var targetParamCast = Expression.Convert(targetParam, targetMethod.DeclaringType);
        var createDelegate = typeof(Delegate).GetMethod(nameof(Delegate.CreateDelegate), BindingFlags.Static | BindingFlags.Public, null, new[] { typeof(Type), typeof(object), typeof(MethodInfo) }, null);
        // Create a delegate of type sourceEvent.EventHandlerType
        var createDelegateCall = Expression.Call(createDelegate, Expression.Constant(sourceEvent.EventHandlerType), targetParam, Expression.Constant(targetMethod));
        // Cast the Delegate to its real type
        var delegateCast = Expression.Convert(createDelegateCall, sourceEvent.EventHandlerType);
        // Subscribe to the event
        var addMethodCall = Expression.Call(sourceParamCast, sourceEvent.AddMethod, delegateCast);
        var lambda = Expression.Lambda<Action<object, object>>(addMethodCall, sourceParam, targetParam);
        var subscriptionAction = lambda.Compile();
        return subscriptionAction;
    }
