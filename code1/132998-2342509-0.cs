        public TaskList(IEventAggregator eventAggregator, 
                        IRegionManager regionManager, 
                        IUnityContainer container)
        {
            _EventAggregator = eventAggregator;
            _RegionManager = regionManager;
            _Container = container;
        }
            IItemListVM vm = _Container.Resolve<IItemListVM>();
            IItemListView view = new IItemListView(vm);
            _RegionManager.Regions["ItemsSummaryRegion"].Add(view);
            _RegionManager.Regions["ItemsSummaryRegion"].Activate(view);
