    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
    
            DataContext = new MainViewModel()
            {
                G1VM = new Grid1ViewModel(),
                G2VM = new Grid2ViewModel()
            };
        }
    }
