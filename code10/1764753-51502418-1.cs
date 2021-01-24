    public partial class MainWindow : Window
    {
        ViewModel viewmodel = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewmodel;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            viewmodel.AddClient();
        }
    }
