    public MainPage()
    {
        this.InitializeComponent();
        Window.Current.Dispatcher.AcceleratorKeyActivated += Dispatcher_AcceleratorKeyActivated;
    }
    
    private void Dispatcher_AcceleratorKeyActivated(Windows.UI.Core.CoreDispatcher sender, Windows.UI.Core.AcceleratorKeyEventArgs args)
    {
        if (IsFocus)
        {
            System.Diagnostics.Debug.WriteLine("Do  Not Fire Your Event ");
            return;
        }
        else
        {
            System.Diagnostics.Debug.WriteLine(" Fire Your Event ");
        }
    
    }
