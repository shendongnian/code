    public partial class MainWindow : Window
    {
        private const int width = 100;
        private const int height = 100;
        private readonly Random random = new Random();
        private readonly byte[] buffer = new byte[3 * width * height];
        private readonly WriteableBitmap bitmap =
            new WriteableBitmap(width, height, 96, 96, PixelFormats.Bgr24, null);
        public MainWindow()
        {
            InitializeComponent();
            image.Source = bitmap;
            var timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(50) };
            timer.Tick += OnTimerTick;
            timer.Start();
        }
        private void OnTimerTick(object sender, EventArgs e)
        {
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var i = 3 * (width * y + x);
                    buffer[i++] = (byte)random.Next(200);
                    buffer[i++] = (byte)random.Next(200);
                    buffer[i++] = (byte)random.Next(200);
                }
            }
            bitmap.WritePixels(new Int32Rect(0, 0, width, height), buffer, 3 * width, 0);
        }
    }
