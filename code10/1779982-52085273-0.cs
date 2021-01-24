    public MainWindow()
    {
        InitializeComponent();
        this.Loaded += MainWindow_Loaded;
    }
    
    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        this.Loaded += MainWindow_Loaded;
        DataContext = new MainViewModel();
    }
