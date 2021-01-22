    public class MyService
    {
        // The method must be virtual.
        public virtual DoSomethingWhichRequiresAuthorization()
        {
        }
    }
    public static class MyServiceFactory
    {
        private static ProxyGenerator _generator;
        private static ProxyGenerator Generator
        {
            get
            {
                if (_generator == null) _generator = new ProxyGenerator();
                return _generator;
            }
        }
        public static MyService Create()
        {
            var interceptor = new AuthorizationInterceptor();
            return (MyService)Generator.CreateClassProxy(
                typeof(MyService), new[] { interceptor });
        }
    }
    public class AuthorizationInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            // invocation.Method contains the MethodInfo
            // of the actually called method.
            AuthorizeMethod(invocation.Method);
        }
    }
