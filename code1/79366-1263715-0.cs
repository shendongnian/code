    public class TraceAttribute : OnMethodBoundaryAspect 
    { 
      public override void OnEntry( MethodExecutionEventArgs eventArgs) 
      { Trace.TraceInformation("Entering {0}.", eventArgs.Method);  } 
    
      public override void OnExit( MethodExecutionEventArgs eventArgs) 
      { Trace.TraceInformation("Leaving {0}.", eventArgs.Method);   } 
    }
