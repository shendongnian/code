    private readonly StatusInfo statusInfo = new StatusInfo();
    public MainWindow()
    {
        InitializeComponent();
        DataContext = statusInfo;
    }
