    public class TraceAttribute : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionEventArgs eventArgs)
        { 
            Tracing.StartOfMethod("Repository");
        }
    
        public override void OnExit(MethodExecutionEventArgs eventArgs)
        { 
            Tracing.EndOfMethod();
        }
    }
