        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
      
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
                 //Do Something
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Dispatcher.InvokeShutdown();
        }
       
