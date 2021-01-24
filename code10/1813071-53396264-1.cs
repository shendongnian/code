    public MainWindow()
    {
        InitializeComponent();
        ps = new ProxyService();
        ps.AcceptConnection();
        DataContext = new BaseViewModel { MessageViewModel = ps };
    }
