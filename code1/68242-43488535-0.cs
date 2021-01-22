    public static class MoqExtensions
    {
        public static IReturnsResult<TMock> DelegateReturns<TMock, TReturn, T>(this IReturnsThrows<TMock, TReturn> mock, T func) where T : class
            where TMock : class
        {
            mock.GetType().Assembly.GetType("Moq.MethodCallReturn`2").MakeGenericType(typeof(TMock), typeof(TReturn))
                .InvokeMember("SetReturnDelegate", BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance, null, mock,
                    new[] { func });
            return (IReturnsResult<TMock>)mock;
        }
    }
