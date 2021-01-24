    public MainPage()
    {
        this.InitializeComponent();
        Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
    }
    private void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
    {           
        if (args.VirtualKey == VirtualKey.Enter)
        {
            System.Diagnostics.Debug.WriteLine(args.VirtualKey.ToString());
            //(Application.Current as App).Broadcast(new ChatMessage { Username = name.Text, Message = text.Text });
            //text.Text = "";
        }
    }
 
