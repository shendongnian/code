    public partial class MainWindow
    {
        IRegionManager _regionManager;
        public MainWindow()
        {
            InitializeComponent();
            _regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            RegionManager.SetRegionManager(ContentRegion, _regionManager);
            Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _regionManager.RequestNavigate("ContentRegion", "ViewA");
        }
    }
