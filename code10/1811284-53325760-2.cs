    public partial class MainWindow
    {
        public MainWindow(AccountViewModel dataContext)
        {
            DataContext = dataContext;
            InitializeComponent();
        }
    }
