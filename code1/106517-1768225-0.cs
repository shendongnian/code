    public partial class Window1 : Window
    {
        DispatcherTimer _timer = new DispatcherTimer();
        public Window1()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            progressBar1.Value = 0;
            progressBar1.Maximum = 100;
            _timer.Interval = TimeSpan.FromMilliseconds( 100);
            _timer.Tick += ProgressUpdateThread;
            _timer.Start();
        }
        private void ProgressUpdateThread( object sender, EventArgs e)
        {
            progressBar1.Value++;
        }
    }
