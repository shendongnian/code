        public SplashScreen()
        {
            InitializeComponent();
            _currentDispatcher = Dispatcher.CurrentDispatcher;
            
            // This is just for the example - start a background method here to call
            // the LoadMainForm rather than the timer elapsed
            System.Timers.Timer loadTimer = new System.Timers.Timer(2000);
            loadTimer.Elapsed += LoadTimerElapsed;
            loadTimer.Start();
        }
        public void LoadMainForm()
        {
            // Do your loading here
            MainForm mainForm = new MainForm();
            
            Visible = false;
            mainForm.ShowDialog();
            System.Timers.Timer closeTimer = new System.Timers.Timer(200);
            closeTimer.Elapsed += CloseTimerElapsed;
            closeTimer.Start();
        }
        private Dispatcher _currentDispatcher;
        private void CloseTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (sender is System.Timers.Timer && sender != null)
            {
                (sender as System.Timers.Timer).Stop();
                (sender as System.Timers.Timer).Dispose();
            }
            _currentDispatcher.BeginInvoke(new Action(() => Close()));
        }
        private void LoadTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (sender is System.Timers.Timer && sender != null)
            {
                (sender as System.Timers.Timer).Stop();
                (sender as System.Timers.Timer).Dispose();
            }
            _currentDispatcher.BeginInvoke(new Action(() => LoadMainForm()));
        }
