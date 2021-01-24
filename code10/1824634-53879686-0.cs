    public static void Application_Initialize() {
     AttachDebugger();
    ...
    }
    
    [Conditional("DEBUG")]
    private void AttachDebugger() {
      if (!System.Diagnostices.Debugger.IsAttached()) {
         System.Diagnostics.Debugger.Launch();
      }
      System.Diagnostics.Debugger.Break();
    }
