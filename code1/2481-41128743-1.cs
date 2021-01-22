    public class ConsoleLoggingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.Writeline("Log before executing");
            invocation.Proceed();
            Console.Writeline("Log after executing");
        }
    }
