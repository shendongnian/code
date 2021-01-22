    public partial class MainPage : PhoneApplicationPage
    {
        private NtpClient _ntpClient;
        public MainPage()
        {
            InitializeComponent();
            _ntpClient = new NtpClient();
            _ntpClient.TimeReceived += new EventHandler<NtpClient.TimeReceivedEventArgs>(_ntpClient_TimeReceived);
        }
        void _ntpClient_TimeReceived(object sender, NtpClient.TimeReceivedEventArgs e)
        {
            this.Dispatcher.BeginInvoke(() =>
                                            {
                                                txtCurrentTime.Text = e.CurrentTime.ToLongTimeString();
                                                txtSystemTime.Text = DateTime.Now.ToUniversalTime().ToLongTimeString();
                                            });
        }
    
        private void UpdateTimeButton_Click(object sender, RoutedEventArgs e)
        {
            _ntpClient.RequestTime();
        }
    }
