        public Thread Updater;
        public MyControl()
        {
            InitializeComponent();
            Loaded += OnLoad;
            Updater = new Thread(ExecuteMarqueeUpdate);
            Updater.Name = "MARQUEEUPDATE";
            Updater.IsBackground = true;
            UpdateMarqueeInfo();
            marqueeText.Text = currentMarqueeText;
            StartMarquee();
        }
        public void ExecuteMarqueeUpdate()
        {
            while (true)
            {
                UpdateMarqueeInfo();
                Thread.Sleep(60000);
            }
        
        private string currentMarqueeText;
        public void UpdateMarqueeInfo()
        {
            Random r = new Random();
            int i = r.Next(5, 8);
            string s = "";
            for(int x = 0; x < i; x++)
            {
                s += "Is it possible to create a marquee or scrolling text in WPF? ";
            }
            currentMarqueeText = s;
        }
        public void StartMarquee()
        {
            var canvas = (Canvas)marqueeText.Parent;
            if (marqueeText.ActualWidth < canvas.ActualWidth) return;
            var duration = new Duration(TimeSpan.FromSeconds(marqueeText.ActualWidth / 60));
            var animation = new DoubleAnimation(canvas.ActualWidth, -marqueeText.ActualWidth, duration);
            Storyboard.SetTargetName(animation, "rtTTransform");
            Storyboard.SetTargetProperty(animation, new PropertyPath(TranslateTransform.XProperty));
            animation.Completed += OnMarqueeScrollComplete;
            storyboard.Children.Clear();
            storyboard.Children.Add(animation);
            storyboard.Begin(marqueeText);
        }
        private void OnMarqueeScrollComplete(object sender, EventArgs e)
        {
            if (!Updater.IsAlive)
            {
                Updater.Start();
            }
            // Stop the running animation then reset the spiffs text.
            // The data updates via the background thread, so just pull as available.
            storyboard.Stop();
            marqueeText.Text = currentMarqueeText;
            // Restart the spiffs marquee animation.
            StartMarquee();
        }
