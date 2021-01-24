    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            Loaded += OnLoaded;
            Unloaded += OnUnloaded;
        }
        private MainViewModel ViewModel => DataContext as MainViewModel;
        private void OnLoaded(object sender, RoutedEventArgs e) =>
            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
        private void OnUnloaded(object sender, RoutedEventArgs e) =>
            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e) =>
            BottomPanel.BeginAnimation(HeightProperty, new DoubleAnimation()
            {
                To = ViewModel.TargetHeight,
                Duration = TimeSpan.FromSeconds(0.3)
            });
    }
