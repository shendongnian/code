        private SerialPortSettingView _serialPortSettingView;
        private RedView _redView;
        private BlueView _blueView;
        public MainWindow()
        {
            _serialPortSettingView = new SerialPortSettingView();
            _redView = new RedView();
            _blueView = new BlueView();
            InitializeComponent();
        }
        private void SerialPortOnOFFButton_Clicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("ON OFF Clicked");
        }
        private void SerialPortSettingButton_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new _serialPortSettingView;
        }
        private void RedViewButton_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new _redview;
        }
        private void BlueViewButton_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new _blueview;
        }
