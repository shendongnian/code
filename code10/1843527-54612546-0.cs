    public partial class MainWindow : Window
    {
        Random random;
        IDisposable subscription;
        public MainWindow()
        {
            InitializeComponent();
            random = new Random();
			subscription =
				Observable
					.Interval(TimeSpan.FromSeconds(1.0))
					.ObserveOnDispatcher()
					.Subscribe(_ => myBar.Value = random.Next(0, 100));
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            subscription.Dispose();
        }
    }
