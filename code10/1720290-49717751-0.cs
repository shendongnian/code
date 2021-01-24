    var parameters = handlerInfo.GetParameters();
    //                                           constructing correct delegate here
    var dynamicHandler = Delegate.CreateDelegate(typeof(Action<>).MakeGenericType(parameters.Single().ParameterType), handlerGroup, handlerInfo);
    HandlerDelegate handler = (p) =>
    {
        // invoking
        dynamicHandler.DynamicInvoke(p);
    };
    cache.Add(parameters.Single().ParameterType, handler);
