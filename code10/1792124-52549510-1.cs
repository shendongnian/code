    public Scenario1()
    {
        this.InitializeComponent();
        Window.Current.Content.PreviewKeyDown += Content_PreviewKeyDown;  
    }
    
    private void Content_PreviewKeyDown(object sender, KeyRoutedEventArgs e)
    {
        e.Handled = e.Key == VirtualKey.Space ? true : false;
    }
