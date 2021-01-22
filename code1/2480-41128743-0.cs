    public class RequireInterception : IContributeComponentModelConstruction
    {
        public void ProcessModel(IKernel kernel, ComponentModel model)
        {
            if (HasAMethodDecoratedByLoggingAttribute(model.Implementation))
            {
                model.Interceptors.Add(new InterceptorReference(typeof(ConsoleLoggingInterceptor)));
                model.Interceptors.Add(new InterceptorReference(typeof(NLogInterceptor)));
            }
        }
        private bool HasAMethodDecoratedByLoggingAttribute(Type implementation)
        {
            foreach (var memberInfo in implementation.GetMembers())
            {
                var attribute = memberInfo.GetCustomAttributes(typeof(LogAttribute)).FirstOrDefault() as LogAttribute;
                if (attribute != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
