    using PostSharp.Aspects;
    [Serializable]
    public sealed class JumperAttribute : OnMethodBoundaryAspect
    {
      public override void OnEntry(MethodExecutionArgs args) 
      { 
        Jumper.StartJumping();
      }     
    
      public override void OnExit(MethodExecutionArgs args) 
      { 
        Jumper.EndJumping(); 
      }
    }
    class SomeClass
    {
      [Jumper()]
      public bool SomeFunction()  // StartJumping *magically* called...          
      {
        // do some code...         
      } // EndJumping *magically* called...
    }
