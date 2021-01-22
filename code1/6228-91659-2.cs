    namespace Tools.CastleWindsor.Interceptors
    {
    using Castle.Core.Interceptor;
    using Castle.Core.Logging;
    using System.Linq;
    public class MethodLoggingInterceptor : AbstractLoggingInterceptor
    {
        private readonly string[] methodNames;
        public MethodLoggingInterceptor(string[] methodNames, ILoggerFactory logFactory) : base(logFactory)
        {
            this.methodNames = methodNames;
        }
        public override void Intercept(IInvocation invocation)
        {
            if ( methodNames.Contains(invocation.Method.Name) )
                base.Intercept(invocation);
        }
    }
    }
