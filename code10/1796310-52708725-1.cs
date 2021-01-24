    public partial class MainWindow : Window
    {
        private Vector speed = new Vector();
        public MainWindow()
        {
            InitializeComponent();
            var timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(20) };
            timer.Tick += TimerTick;
            timer.Start();
        }
        private void TimerTick(object sender, EventArgs e)
        {
            var pos = new Point(Canvas.GetLeft(ellipse), Canvas.GetTop(ellipse)) + speed;
            Canvas.SetLeft(ellipse, Math.Min(Math.Max(pos.X, 0), canvas.ActualWidth));
            Canvas.SetTop(ellipse, Math.Min(Math.Max(pos.Y, 0), canvas.ActualHeight));
        }
        private void WindowKeyDown(object sender, KeyEventArgs e)
        {
            speed.X = 0;
            speed.Y = 0;
            switch (e.Key)
            {
                case Key.Left:
                    speed.X = -10;
                    break;
                case Key.Right:
                    speed.X = 10;
                    break;
                case Key.Up:
                    speed.Y = -10;
                    break;
                case Key.Down:
                    speed.Y = 10;
                    break;
            }
        }
    }
