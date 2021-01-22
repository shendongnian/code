    public class LoggingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            if (Attribute.IsDefined(invocation.Method, typeof(LogAttribute))
            {
                Console.Writeline("Method called: "+ invocation.Method.Name);
            }
            invocation.Proceed();
        }
    }
