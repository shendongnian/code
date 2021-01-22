    [Conditional("DEBUG")]
    void DebugBreak()
    {
      if(System.Diagnostics.Debugger.IsAttached)
        System.Diagnostics.Debugger.Break();
    }
