    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer timer = new DispatcherTimer();
        private readonly Rectangle s = new Rectangle();
        public MainWindow()
        {
            InitializeComponent();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
            s.Width = 20;
            s.Height = 20;
            s.Fill = Brushes.Black;
            Canvas.SetLeft(s, 0);
            map.Children.Add(s);
        }
        public void Timer_Tick(object sender, EventArgs e)
        {
            Canvas.SetLeft(s, Canvas.GetLeft(s) + 20);
        }
    }
