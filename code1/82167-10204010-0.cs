    [Serializable]
    public class MyAspectAttribute : MethodLevelAspect
    {
        object exceptionReturn = null;
        public MyAspectAttribute(object ExceptionReturn) : base()
        {
        }
        [OnMethodInvokeAdvice, SelfPointcut]
        [AdviceDependency(AspectDependencyAction.Order, AspectDependencyPosition.Before, "OnEntry")]
        public void OnInvoke(MethodInterceptionArgs args)
        {
            try
            {
                args.Proceed();
            }
            catch (Exception exc)
            {
                // do logging here
                args.ReturnValue = exceptionReturn;
            }
        }
        [OnMethodExceptionAdvice, SelfPointcut]
        public void OnException(MethodExecutionArgs args)
        {
        }
        [OnMethodEntryAdvice, SelfPointcut]
        public void OnEntry(MethodExecutionArgs args)
        {
        }
        [OnMethodExitAdvice, SelfPointcut]
        [AdviceDependency(AspectDependencyAction.Order, AspectDependencyPosition.After, "OnInvoke")]
        [AdviceDependency(AspectDependencyAction.Order, AspectDependencyPosition.After, "OnEntry")]
        public void OnExit(MethodExecutionArgs args)
        {
             // your exit statements, such as committing transaction etc.
        }
    }
