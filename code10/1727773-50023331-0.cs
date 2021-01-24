        private DispatcherTimer _timer;
        protected override void OnStartup(StartupEventArgs e)
        {
            _timer = new DispatcherTimer();
            _timer.Tick += Timer_Tick;
            _timer.Interval = new TimeSpan(0,0,0,20,0);
            _timer.Start();
            EventManager.RegisterClassHandler(typeof(Window),Window.MouseMoveEvent, new RoutedEventHandler(Reset_Timer));
            EventManager.RegisterClassHandler(typeof(Window), Window.MouseDownEvent, new RoutedEventHandler(Reset_Timer));
            EventManager.RegisterClassHandler(typeof(Window), Window.KeyDownEvent, new RoutedEventHandler(Reset_Timer));
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("Ticked");
        }
        private void Reset_Timer(object sender, EventArgs e)
        {
            _timer.Interval = new TimeSpan(0,0,0,20,0);
        }
