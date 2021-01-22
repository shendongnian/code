    [Serializable]
    public sealed class LogExceptionAttribute : OnExceptionAspect
    {
        public override void OnException(MethodExecutionEventArgs eventArgs)
        {
            //do some logging here
        }
    }
