    public partial class MainWindow : Window
    {
        private const int width = 100;
        private const int height = 100;
        private readonly Random random = new Random();
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
            bitmap.Lock();
            unsafe
            {
                byte* buffer = (byte*)bitmap.BackBuffer;
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
            }
            bitmap.AddDirtyRect(new Int32Rect(0, 0, width, height));
            bitmap.Unlock();
        }
    }
