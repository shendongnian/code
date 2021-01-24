    object result = null;
    if (method.Method.ReturnType.IsSubclassOf(typeof(Task)))
    {
        if (method.Method.ReturnType.IsConstructedGenericType)
        {
            dynamic tmp = method.DynamicInvoke(args);
            result = tmp.GetAwaiter().GetResult();
        }
        else
        {
            (method.DynamicInvoke(args) as Task).GetAwaiter().GetResult();
        }
    }
    else
    {
        result = method.DynamicInvoke(args);
    }
