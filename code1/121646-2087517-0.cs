        private System.Timers.Timer ClickTimer;
        private int ClickCounter;
        public MyView()
        {
            ClickTimer = new Timer(300);
            ClickTimer.Elapsed += new ElapsedEventHandler(EvaluateClicks);
            InitializeComponent();
        }
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ClickTimer.Stop();
            ClickCounter++;
            ClickTimer.Start();
        }
        private void EvaluateClicks(object source, ElapsedEventArgs e)
        {
            ClickTimer.Stop();
            // Evaluate ClickCounter here
            ClickCounter = 0;
        }
