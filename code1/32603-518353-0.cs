    public bool IsDesignMode
    {
       get
          {
             return (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv");
          }
    }
