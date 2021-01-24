    public Scenario1()
    {
        this.InitializeComponent();
        Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
    }
    
    private void CoreWindow_KeyDown(CoreWindow sender, KeyEventArgs args)
    {
       if(args.VirtualKey == VirtualKey.Space)
        {
           //pause or play the player
        }
    }
