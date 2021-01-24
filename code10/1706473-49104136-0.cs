    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
        }
        public string MyValue { get; set; } = "Hello";
    }
