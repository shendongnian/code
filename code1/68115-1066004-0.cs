    public class ExceptionSuppressionInterceptor : Castle.Core.Interceptor.IInterceptor
    {
       public void Intercept(IInvocation invocation)
       {
           try {
               invocation.Proceed();
           }
           catch (Exception ex) {
                // Suppressed!
           }
       }
    }
