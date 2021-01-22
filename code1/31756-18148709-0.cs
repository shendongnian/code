        private Timer timer;
        public Service()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            SetTimer();
        }
        private void SetTimer()
        {
            if (timer == null)
            {
                timer = new Timer();
                timer.AutoReset = true;
                timer.Interval = 60000 * Convert.ToDouble(ConfigurationManager.AppSettings["IntervalMinutes"]);
                timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
                timer.Start();
            }
        }
        private void timer_Elapsed(object source, System.Timers.ElapsedEventArgs e)
        {
            //Do some thing logic here
        }
        protected override void OnStop()
        {
            // disposed all service objects
        }
    }
