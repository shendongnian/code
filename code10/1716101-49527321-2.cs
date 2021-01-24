    public void PrgBarInc()
    {
      if (this.IsHandleCreated)
      {
        if (this.InvokeRequired)
        {
           this.Invoke(new MethodInvoker(PrgBarInc));
        }
        else
        {
           prgBar.Increment("your val");
        }
    }
