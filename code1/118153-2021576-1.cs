    public MyCoolModule : IModule
    {
         IRegionManager _mgr;
         IUnityContainer _container;
         public MyCoolModule(IRegionManager mgr, IUnityContainer container)
         {
              _mgr = mgr;
              _container = container;
         }
    
         public void Initialize()
         {
              _mgr.RegisterViewWithRegion(RegionNames.FeatureSelection, 
                                          () => _container.Resolve<MyViewModel>());
         }
    
    }
