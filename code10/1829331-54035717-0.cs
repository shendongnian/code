    public MainPage() {
            this.InitializeComponent();
            StartTimers();
        }
        DispatcherTimer dispatcherTimer;
        public void StartTimers() {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }
        // callback runs on UI thread
        void dispatcherTimer_Tick(object sender, object e) {
            // execute repeating task here
            Random randRotate = new Random();
            RotateTransform imageRotate = new RotateTransform();
            redBaloon.RenderTransform = imageRotate;
            imageRotate.Angle = randRotate.Next(-5, 5);
        }
