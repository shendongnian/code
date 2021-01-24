    public partial class MainWindow : Window
    {
        public ViewModel ViewModel { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            
            ViewModel = new ViewModel();
            DataContext = ViewModel;
        }
    }
