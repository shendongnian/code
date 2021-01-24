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
        private readonly Dictionary<CellState, Color> stateColors =
            new Dictionary<CellState, Color>
            {
                { CellState.Empty, Colors.Black },
                { CellState.Tree, Colors.Green },
                { CellState.Burning, Colors.Yellow }
            };
        private CellState[,] cells = new CellState[100, 100];
        private double ignitionProbability = 0.0001;
        private double newTreeProbability = 0.01;
        public MainWindow()
        {
            InitializeComponent();
            image.Source = bitmap;
            var timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(50) };
            timer.Tick += OnTimerTick;
            timer.Start();
        }
        private bool IsCellBurning(int y, int x)
        {
            return x >= 0 && x < width && y >= 0 && y < height
                && cells[y, x] == CellState.Burning;
        }
        private bool StartsBurning(int y, int x)
        {
            return IsCellBurning(y - 1, x - 1)
                || IsCellBurning(y - 1, x)
                || IsCellBurning(y - 1, x + 1)
                || IsCellBurning(y, x - 1)
                || IsCellBurning(y, x + 1)
                || IsCellBurning(y + 1, x - 1)
                || IsCellBurning(y + 1, x)
                || IsCellBurning(y + 1, x + 1)
                || random.NextDouble() <= ignitionProbability;
        }
        private void UpdateCells()
        {
            CellState[,] newCells = new CellState[100, 100];
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    newCells[y, x] = cells[y, x];
                    switch (newCells[y, x])
                    {
                        case CellState.Burning:
                            newCells[y, x] = CellState.Empty;
                            break;
                        case CellState.Empty:
                            if (random.NextDouble() <= newTreeProbability)
                            {
                                newCells[y, x] = CellState.Tree;
                            }
                            break;
                        case CellState.Tree:
                            if (StartsBurning(y, x))
                            {
                                newCells[y, x] = CellState.Burning;
                            }
                            break;
                    }
                }
            }
            cells = newCells;
        }
        private void DrawCells()
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
        private void OnTimerTick(object sender, EventArgs e)
        {
            UpdateCells();
            DrawCells();
        }
    }
