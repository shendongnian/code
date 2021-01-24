    public MainPage()
    {
        this.InitializeComponent();
        this.PreviewKeyDown += MainPage_PreviewKeyDown;
    }
    
    private void MainPage_PreviewKeyDown(object sender, KeyRoutedEventArgs e)
    {
        if (e.Key == VirtualKey.Tab)
        {
            e.Handled = true;
        }
    }
