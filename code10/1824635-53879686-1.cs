    public static void Application_Initialize() {
     AttachDebugger();
    ...
    }
    
    [Conditional("DEBUG")]
    private void AttachDebugger() {
      if (!System.Diagnostics.Debugger.IsAttached()) {
         System.Diagnostics.Debugger.Launch();
      }
      System.Diagnostics.Debugger.Break();
    }
