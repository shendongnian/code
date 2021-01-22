    private readonly IRegionManager _regionManager;
    private readonly IUnityContainer _container;
    
    public SilverlightUserControl1(IRegionManager regionManager, IUnityContainer container)
    {
        _regionManager = regionManager;
        _container = container;
    }
    private Button1_Click(object sender, RoutedEventArgs e)
    {
        var statusBarView = _container.Resolve<StatusBarView>();
        statusBarRegion = _regionManager.Regions["StatusBarRegion"];
        statusBarRegion.Add(statusBarView, "StatusBarView");
        statusBarRegion.Activate(statusBarView);
        // or you could remove all views in `ActiveViews` and add the view then
        // (no need to activate)
    }
