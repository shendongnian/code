    public partial class MainWindow : Window
    {
        private Process _process = null;
        public MainWindow()
        {
            InitializeComponent();
            _process = new Process();
            _process.StartInfo.FileName = @"notepad.exe";
            _process.Start();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (_process == null) return;
            _process.Kill();
            _process = null;
        }
    }
