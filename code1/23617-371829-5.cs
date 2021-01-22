    public override ISite Site
    {
      get { return base.Site; }
      set
      {
        base.Site = value;
        if (value == null)
        {
          return;
        }
    
        IDesignerHost host = value.GetService(
    		typeof(IDesignerHost)) as IDesignerHost;
        IComponent componentHost = host.RootComponent;
        if (componentHost is ContainerControl)
        {
          ContainerControl = componentHost as ContainerControl;
        }
      }
    }
