    public MainWindow()
    {
        InitializeComponent();
        ObservableCollection<byte> bytes = new ObservableCollection<byte>();
        bytes.Add(11);
        bytes.Add(12);
        bytes.Add(13);
        bytes.Add(14);
        Items.DataContext = bytes;
    }
