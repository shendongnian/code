    public partial class MainWindow : Window
    {
        private const int width = 100;
        private const int height = 100;
        private readonly WriteableBitmap bitmap =
            new WriteableBitmap(width, height, 96, 96, PixelFormats.Bgr24, null);
        private readonly Random random = new Random();
        enum CellState
        {
            Empty, Tree, Burning
        }
        private readonly CellState[,] cells = new CellState[100, 100];
        private readonly Dictionary<CellState, Color> stateColors =
            new Dictionary<CellState, Color>
            {
                { CellState.Empty, Colors.Black },
                { CellState.Tree, Colors.Green },
                { CellState.Burning, Colors.Yellow }
            };
        private double ignitionProbability = 0.001;
        private double newTreeProbability = 0.01;
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
                    if (cells[y, x] == CellState.Burning)
                    {
                        cells[y, x] = CellState.Empty;
                    }
                    else if (cells[y, x] == CellState.Empty)
                    {
                        if (random.NextDouble() <= newTreeProbability)
                        {
                            cells[y, x] = CellState.Tree;
                        }
                    }
                    else if (x > 0 && cells[y, x - 1] == CellState.Burning
                        || y > 0 && cells[y - 1, x] == CellState.Burning
                        || x < width - 1 && cells[y, x + 1] == CellState.Burning
                        || y < height - 1 && cells[y + 1, x] == CellState.Burning
                        || random.NextDouble() <= ignitionProbability)
                    {
                        cells[y, x] = CellState.Burning;
                    }
                }
            }
            bitmap.Lock();
            unsafe
            {
                byte* buffer = (byte*)bitmap.BackBuffer;
                for (var y = 0; y < height; y++)
                {
                    for (var x = 0; x < width; x++)
                    {
                        var i = 3 * (width * y + x);
                        var color = stateColors[cells[y, x]];
                        buffer[i++] = color.B;
                        buffer[i++] = color.G;
                        buffer[i++] = color.R;
                    }
                }
            }
            bitmap.AddDirtyRect(new Int32Rect(0, 0, width, height));
            bitmap.Unlock();
        }
    }
