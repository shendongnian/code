    public static ICallbackResult OutCallback<TOut>(this ICallback mock, OutAction<TOut> action)
    {
        return OutCallbackInternal(mock, action);
    }
    public static ICallbackResult OutCallback<T1, TOut>(this ICallback mock, OutAction<T1, TOut> action)
    {
        return OutCallbackInternal(mock, action);
    }
    private static ICallbackResult OutCallbackInternal(ICallback mock, object action)
    {
        mock.GetType().Assembly.GetType("Moq.MethodCall")
            .InvokeMember("SetCallbackWithArguments", BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance, null, mock, new[] { action });
        return (ICallbackResult)mock;
    }
