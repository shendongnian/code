    class Class2
    {
        public string[] Names { get; } = { "USA", "Canada", "China", "Peru", "Germany" };
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new Class2();
        }
    }
