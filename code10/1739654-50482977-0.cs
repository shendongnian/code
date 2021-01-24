    private DispatcherTimer Timer { get; set; }
    public MainPage()
    {
        this.InitializeComponent();
        CmdBar.ClosedDisplayMode = AppBarClosedDisplayMode.Hidden;            
        Timer = new DispatcherTimer(){Interval = TimeSpan.FromSeconds(5) };
        Timer.Tick += (sender, args) => { CmdBar.ClosedDisplayMode = AppBarClosedDisplayMode.Hidden; };
    }
    public async void OnPointerMoved(object Sender, PointerRoutedEventArgs e)
    {
        Timer.Stop();
        CmdBar.ClosedDisplayMode = AppBarClosedDisplayMode.Compact;
        Timer.Start();            
    }
