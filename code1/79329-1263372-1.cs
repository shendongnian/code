    public Window1()
    {
        InitializeComponent();
        
        Loaded += new RoutedEventHandler(Window1_Loaded);
    }
    void Window1_Loaded(object sender, RoutedEventArgs e)
    {
        WebBrowser1_PreviewKeyDown(this, new KeyEventArgs(Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 1, Key.LeftShift));
        WebBrowser1_PreviewKeyDown(this, new KeyEventArgs(Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 1, Key.Tab));
    }
    private void WebBrowser1_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine(e.Key);
    }
