    public partial class MainWindow : Window
    {
        public ViewModel ViewModel { get; }
        public MainWindow()
        {     
            ViewModel = new ViewModel();
            InitializeComponent();
        }
    }
