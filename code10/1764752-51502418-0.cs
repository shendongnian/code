    public partial class MainWindow : Window
    {
        ViewModel viewmodel;
        public MainWindow()
        {
            InitializeComponent();
            viewModel = (ViewModel)DataContext;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            viewmodel.AddClient();
        }
    }
