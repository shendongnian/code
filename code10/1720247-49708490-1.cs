    public MainWindow()
    {
        PositionTabs = new ObservableCollection<PositionTab>();
        for (int i = 0; i <= 4; i++)
        {
            PositionTabs.Add(new PositionTab(i));
        }
         
        InitializeComponent();
    }
