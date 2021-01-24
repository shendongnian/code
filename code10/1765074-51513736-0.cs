    public partial class MainWindow : Window
    {
        public ViewModel ViewModel { get; private set; }
        public MainWindow()
        {     
            ViewModel = new ViewModel();
            InitializeComponent();
        }
    }
