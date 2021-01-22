    namespace Tools.CastleWindsor.Interceptors
    {
    using System;
    using System.Text;
    using Castle.Core.Interceptor;
    using Castle.Core.Logging;
    public abstract class AbstractLoggingInterceptor : IInterceptor
    {
        protected readonly ILoggerFactory logFactory;
        protected AbstractLoggingInterceptor(ILoggerFactory logFactory)
        {
            this.logFactory = logFactory;
        }
        public virtual void Intercept(IInvocation invocation)
        {
            ILogger logger = logFactory.Create(invocation.TargetType);
            try
            {
                StringBuilder sb = null;
                if (logger.IsDebugEnabled)
                {
                    sb = new StringBuilder(invocation.TargetType.FullName).AppendFormat(".{0}(", invocation.Method);
                    for (int i = 0; i < invocation.Arguments.Length; i++)
                    {
                        if (i > 0)
                            sb.Append(", ");
                        sb.Append(invocation.Arguments[i]);
                    }
                    sb.Append(")");
                    logger.Debug(sb.ToString());
                }
                invocation.Proceed();
                if (logger.IsDebugEnabled && invocation.ReturnValue != null)
                {
                    logger.Debug("Result of " + sb + " is: " + invocation.ReturnValue);
                }
            }
            catch (Exception e)
            {
                logger.Error(string.Empty, e);
                throw;
            }
        }
    }
    }
