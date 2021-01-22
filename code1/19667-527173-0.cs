    public MainView()
    {
        InitializeComponent();
        this.Loaded += new RoutedEventHandler(MainView_Loaded);
    }
    void MainView_Loaded(object sender, RoutedEventArgs e)
    {
        Window parentWindow = Window.GetWindow(this);
        ...
    }
