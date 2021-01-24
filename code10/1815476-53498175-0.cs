    public NotifyIconViewModel NotifyIconVM { get; set; }
    
    MainWindow() 
    { 
        InitializeComponent();
        NotifyIconVM = new NotifyIconViewModel();
        DataContext = NotifyIconVM;
    }
