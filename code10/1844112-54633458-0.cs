    public sealed partial class MainWindow : Window, IDisposable
    {
        private readonly ServiceHost _host = new ServiceHost(typeof(GestorAplicacionesService));
        public MainWindow()
        {
            InitializeComponent();
            _host.Open();
            Closing += MainWindow_Closing;
        }
        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            Dispose();
        }
        public void Dispose()
        {
            _host.Close();
            _host.Dispose();
        }
    }
