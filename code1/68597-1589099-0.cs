    public class Component2TracerAttribute : OnMethodBoundaryAspect 
    { 
      public override void OnEntry( MethodExecutionEventArgs eventArgs) 
      { 
         if (eventArgs.Method == somethingOnComponent2) // Pseudo-code
         {
            Trace.TraceInformation("Entering {0}.", eventArgs.Method);  
         }
      } 
    
      public override void OnExit(MethodExecutionEventArgs eventArgs) 
      { 
          if (eventArgs.Method == somethingOnComponent2) // Pseudo-code
          {
             Trace.TraceInformation("Leaving {0}.", eventArgs.Method);   
          }
      } 
    }
