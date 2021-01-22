    [Serializable]
    public class RuntimeConditional : OnMethodBoundaryAspect 
    {
        private string[] _conditions;
        public RuntimeConditional(params string[] conditions)
        {
            _conditions = conditions;
        }
        public override void OnEntry(MethodExecutionEventArgs eventArgs)
        {
            if (_conditions[0] == "Bob")
            {
                eventArgs.FlowBehavior = FlowBehavior.Return; // return immediately without executing
            }
        }
    }
