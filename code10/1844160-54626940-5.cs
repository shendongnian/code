    public ObservableCollection<ColorData> ColorCollection { get; set; }
    public MainWindow()
    {
        ColorCollection = new ObservableCollection<ColorData>();
        InitializeComponent();
        this.DataContext = this;
    }
