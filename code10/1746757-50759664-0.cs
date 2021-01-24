    public MainPage()
    {
        InitializeComponent();
        Window.Current.CoreWindow.CharacterReceived += CoreWindow_CharacterReceived;
    }
    private async void CoreWindow_CharacterReceived(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.CharacterReceivedEventArgs args)
    {
        if (args.KeyCode == 27 ) //Escape
        {
             // your code here fore Escape key
        }
        if (args.KeyCode == 13) //Enter
        {
             // your code here fore Enter key
        }
    }
