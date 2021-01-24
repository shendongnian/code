    class ViewModel
    {
        public Player Player { get; } = new Player();
        public Achievement Achievement { get; } = new Achievement();
    }
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new ViewModel();
    }
