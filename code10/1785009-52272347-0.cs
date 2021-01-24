    class ViewInjectionMainViewModel :BindableBase
        {
            IUnityContainer _container;
            IRegionManager _regionMansger;
            public ViewInjectionMainViewModel(IUnityContainer container, IRegionManager regionManager)
            {
                _container = container;
                         
    
                _regionMansger = regionManager;
    
                System.Windows.Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Send, new Action(() =>
                {
                    var view = _container.Resolve<DummyView>();
    
    
                    IRegion region = _regionMansger.Regions["ViewInjectionMain_MainRegion"];
    
    
                    region.Add(view);
                }));
            }
            
        }
