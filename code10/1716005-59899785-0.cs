    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=RouteMiningDB;Trusted_Connection=True;";
        RouteMiningDAL.RouteMiningDataContext db = new RouteMiningDAL.RouteMiningDataContext(new DbContextOptionsBuilder().UseSqlServer(connectionString).Options);
        IZIPCodeInfoRepository zipCodeRepo = new RouteMiningDAL.SQLZIPCodeInfoRepository(db);
        ZIPCodeInfoService zipCodeInfoService = new ZIPCodeInfoService(zipCodeRepo);
		StockHistoryService stockHistoryService = StockHistoryService();
		StockHistoryViewModel stockHistoryViewModel = new StockHistoryViewModel(stockHistoryService);
        ZIPCodeInfoViewModel zipCodeInfoViewModel = new ZIPCodeInfoViewModel(zipCodeInfoService, stockHistoryViewModel);
        ZIPCodeInfoView zipCodeInfoView = new ZIPCodeInfoView(zipCodeInfoViewModel);
        MainWindow mainWindow = new MainWindow();
        mainWindow.Content = zipCodeInfoView;
        mainWindow.Show();
    }
