    public class LoggingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            if (Attribute.IsDefined(invocation.Method, typeof(LogAttribute))
            {
                Console.Write("Log: Method Called: "+ invocation.Method.Name);
            }
            invocation.Proceed();
        }
    }
