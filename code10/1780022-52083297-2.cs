    internal static ProcessedContext Process(this IContext context)
    {
        if (context is IBasicContext basicContext)
        {
            return basicContext.Process();
        }
        else if (context.GetType().GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(ITypedContext<>)))
        {
            Type typedContextInterface = context.GetType().GetInterfaces().First(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(ITypedContext<>));
            MethodInfo processGenericMethod = GetType().GetTypeInfo().GetMethod(nameof(ProcessGeneric), BindingFlags.NonPublic | BindingFlags.Static).MakeGenericMethod(typedContextInterface.GetGenericArguments()[0]);
            return (ProcessedContext)processGenericMethod.Invoke(null, new object[] { context });
        }
    }
    internal static ProcessedContext ProcessGeneric<T>(ITypedContext<T> context)
    {
        // Do stuff here to create processed context
    }
