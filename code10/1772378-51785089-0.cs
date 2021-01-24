    //Add registration to the composition root
    container.InterceptWith<MonitoringInterceptor>(serviceType => serviceType.Name.EndsWith("Repository"));`
    
    // Here is an example of an interceptor implementation.
    // NOTE: Interceptors must implement the IInterceptor interface:
    private class MonitoringInterceptor : IInterceptor {
        private readonly ILogger logger;
    
      public MonitoringInterceptor(ILogger logger) {
            this.logger = logger;
        }
    
        public void Intercept(IInvocation invocation) {
            var watch = Stopwatch.StartNew();
    
            // Calls the decorated instance.
            invocation.Proceed();
    
            var decoratedType = invocation.InvocationTarget.GetType();
    
            this.logger.Log(string.Format("{0} executed in {1} ms.",
                decoratedType.Name, watch.ElapsedMilliseconds));
        }
    }
