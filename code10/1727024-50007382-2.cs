    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel viewModel;
        public MainWindowViewModel ViewModel
        {
            get { return viewModel; }
            set
            {
                viewModel = value;
                DataContext = viewModel;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new MainWindowViewModel();
        }
        private async void loadButton_Click(object sender, RoutedEventArgs e)
        {
            var data = await ViewModel.LoadData();
            //display the data on the UI (only testing code)
            StringBuilder result = new StringBuilder();
            data.ForEach(item => result.Append($"{item},"));
            MessageBox.Show(result.ToString());
        }
    }
 
