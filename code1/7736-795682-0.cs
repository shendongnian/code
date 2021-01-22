    protected override void OnStart(string[] args)
    {
      if (args.Contains<string>("DEBUG_SERVICE"))
      {
        Debugger.Break();
      }
      ...
    }
