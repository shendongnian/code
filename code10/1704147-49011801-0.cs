    public MainWindow()
    {
        InitializeComponent();
        Closing += (sender, args) =>
        {
            args.Cancel = !CheckSettings();
            ...
        };
    }
    public bool CheckSettings()
    {
       // Check and return true if the form can be closed
    }
