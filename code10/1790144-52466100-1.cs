        public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
