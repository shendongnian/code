    [Serializable]
    [MulticastAttributeUsage(... Add Appropriate MulticastTargets ...)]
    public sealed class LogExceptionAttribute : ExceptionHandlerAspect
    {
        public override void OnException(MethodExecutionEventArgs eventArgs)
        {
            //do some logging here
        }
    }
