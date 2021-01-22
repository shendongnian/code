    public MainWindow()
        {
            InitializeComponent();
            var timer = new DispatcherTimer {Interval = TimeSpan.FromSeconds(10)};
            timer.Tick += delegate
            {
                timer.Stop();
                MessageBox.Show("Logoff trigger");
                timer.Start();
            };
            timer.Start();
            InputManager.Current.PostProcessInput += delegate(object s,  ProcessInputEventArgs r)
            {
                if (r.StagingItem.Input is MouseButtonEventArgs || r.StagingItem.Input is KeyEventArgs)
                    timer.Interval = TimeSpan.FromSeconds(10);
            };
        }
