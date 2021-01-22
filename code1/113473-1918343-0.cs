    public MyModule : IModule
    {
         IRegionManager _mgr;
         public MyModule(IRegionManager mgr)
         {
              _mgr = mgr;
         }
    
         public void Initialize()
         {
              _mgr.RegisterViewWithRegion("Workspace", typeof(MyPlugin));
         }
    
    }
