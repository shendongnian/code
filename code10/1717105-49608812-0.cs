    public MainPage()
    {
        this.InitializeComponent();
        Window.Current.CoreWindow.KeyUp += CoreWindow_KeyUp;
    }
    private void CoreWindow_KeyUp(CoreWindow sender, KeyEventArgs args)
    {        
        if (IsCtrlKeyPressed())
        {
            switch (args.VirtualKey)
            {
                case VirtualKey.H: taga.Navigate(new Uri("http://www.bing.com")); break;
            }
        }
    }
    private static bool IsCtrlKeyPressed()
    {
        var ctrlState = CoreWindow.GetForCurrentThread().GetKeyState(VirtualKey.Control);
        return (ctrlState & CoreVirtualKeyStates.Down) == CoreVirtualKeyStates.Down;
    }
