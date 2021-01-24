    public MainWindow()
    {
        InitializeComponent();
        const int n = 30;
        for (int i = 0; i < n; ++i)
        {
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
        }
    }
