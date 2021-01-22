    void OnChannelMessage(OnChannelEventArgs e)
    {
      foreach(IModule module in Modules)
      {
         module.HandleMessage(e);
      }
    }
    
    [Import]
    public IEnumerable<IModule> Modules { get; set; }
