    public partial class MainWindow : Window
    {
        private WriteableBitmap _bitmap;
        private readonly Random _random = new Random();
        private readonly Stopwatch _stopwatch = new Stopwatch();
        private const int White = 0x000000;
        private const int Red = 0x00FF0000;
        private int _width;
        private int _height;
        public MainWindow()
        {
            InitializeComponent();
            CanvasImage.Loaded += OnLoaded;
        }
        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            _width = (int)DrawableCanvas.ActualWidth;
            _height = (int)DrawableCanvas.ActualHeight;
            _bitmap = new WriteableBitmap(_width, _height, 96, 96, PixelFormats.Bgr32, null);
            CanvasImage.Source = _bitmap;
            while (true)
            {
                unsafe
                {
                    for (var index = 0; index < _width * _height; index++)
                        *((int*)_bitmap.BackBuffer + index) = White;
                }
                _stopwatch.Start();
                for (var index = 0; index < 1000; index++)
                {
                    var start = _random.Next(0, _width);
                    var points = Enumerable.Range(0, _width).Select(x => new Point(x % _width + start, x % _height));
                    UpdateImage(points);
                }
                
                Debug.WriteLine($"Duration: {_stopwatch.ElapsedMilliseconds} ms");
                _stopwatch.Reset();
                await Task.Delay(300);
            }
        }
        private void UpdateImage(IEnumerable<Point> points)
        {
            _bitmap.Lock();
            foreach (var point in points)
            {
                var x = (int)point.X;
                var y = (int)point.Y;
                var offset = _width * y + x;
                unsafe
                {
                    *((int*)_bitmap.BackBuffer + offset) = Red;
                }
            }
            _bitmap.AddDirtyRect(new Int32Rect(0, 0, _width, _height));
            _bitmap.Unlock();
        }
    }
