    public partial class MainWindow : Window
    {
        private enum CellState
        {
            Empty, Tree, Burning
        }
        private const int width = 400;
        private const int height = 400;
        private readonly WriteableBitmap bitmap =
            new WriteableBitmap(width, height, 96, 96, PixelFormats.Bgr24, null);
        private readonly byte[] buffer = new byte[3 * width * height];
        private readonly Random random = new Random();
        private readonly Dictionary<CellState, Color> stateColors =
            new Dictionary<CellState, Color>
            {
                { CellState.Empty, Colors.Black },
                { CellState.Tree, Colors.Green },
                { CellState.Burning, Colors.Yellow }
            };
        private CellState[,] cells = new CellState[height, width];
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
        private async void OnTimerTick(object sender, EventArgs e)
        {
            await Task.Run(() => UpdateCells());
            bitmap.WritePixels(new Int32Rect(0, 0, width, height), buffer, 3 * width, 0);
        }
        private bool IsBurning(int y, int x)
        {
            return x >= 0 && x < width && y >= 0 && y < height
                && cells[y, x] == CellState.Burning;
        }
        private bool StartsBurning(int y, int x)
        {
            return IsBurning(y - 1, x - 1)
                || IsBurning(y - 1, x)
                || IsBurning(y - 1, x + 1)
                || IsBurning(y, x - 1)
                || IsBurning(y, x + 1)
                || IsBurning(y + 1, x - 1)
                || IsBurning(y + 1, x)
                || IsBurning(y + 1, x + 1)
                || random.NextDouble() <= ignitionProbability;
        }
        private CellState GetNewState(int y, int x)
        {
            var state = cells[y, x];
            switch (state)
            {
                case CellState.Burning:
                    state = CellState.Empty;
                    break;
                case CellState.Empty:
                    if (random.NextDouble() <= newTreeProbability)
                    {
                        state = CellState.Tree;
                    }
                    break;
                case CellState.Tree:
                    if (StartsBurning(y, x))
                    {
                        state = CellState.Burning;
                    }
                    break;
            }
            return state;
        }
        private void UpdateCells()
        {
            var newCells = new CellState[height, width];
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    newCells[y, x] = GetNewState(y, x);
                    var color = stateColors[newCells[y, x]];
                    var i = 3 * (width * y + x);
                    buffer[i++] = color.B;
                    buffer[i++] = color.G;
                    buffer[i++] = color.R;
                }
            }
            cells = newCells;
        }
    }
