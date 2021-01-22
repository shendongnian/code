    [Serializable]
    public class RuntimeConditional : OnMethodInvocationAspect
    {
        private string[] _conditions;
        public RuntimeConditional(params string[] conditions)
        {
            _conditions = conditions;
        }
        public override void OnInvocation(MethodInvocationEventArgs eventArgs)
        {
            if (_conditions[0] == "Bob") // do whatever check you want here
            {
                eventArgs.Proceed();
            }
        }
    }
