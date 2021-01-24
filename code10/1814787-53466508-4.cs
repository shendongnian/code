    private CoreDispatcher _dispatcher;
    public MyPage()
    {
        this.InitializeComponent();
        _dispatcher = Window.Current.Dispatcher;
        
        ...
    }
