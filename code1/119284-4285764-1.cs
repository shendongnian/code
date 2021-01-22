    private readonly IRegionManager _regionManager;
    [ImportingConstructor]
    public ShellViewModel(IRegionManager regionManager)
    {
      this._regionManager = regionManager;
      Dispatcher dp = Dispatcher.CurrentDispatcher;
      dp.BeginInvoke(DispatcherPriority.ApplicationIdle, new ThreadStart(delegate
      {
        if (this._regionManager.Regions.ContainsRegionWithName("MyRegion"))
          this._regionManager.Regions["MyRegion"].SortComparison = CompareViews;
      }));
    }
