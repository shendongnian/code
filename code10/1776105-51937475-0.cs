    public class LedDisplayer : IDisposable
    {
        public LedDisplayer(Control control)
        {
            _backColor = control.BackColor;
            _graphics = control.CreateGraphics();
            _onBrush = new SolidBrush(Color.Red);
            _offBrush = new SolidBrush(Color.Black);
            control.MouseDown += MouseDown;
            // width and height of your tiny boxes
            _width = 5; 
            _height = 5;
            // margin between tiny boxes
            _margin = 1;
        }
        private readonly Graphics _graphics;
        private readonly Color _backColor;
        private readonly SolidBrush _onBrush;
        private readonly SolidBrush _offBrush;
        private readonly int _width;
        private readonly int _height;
        private readonly int _margin;
        private bool[,] _values;
        // call this method first of all to initialize the Displayer
        public void Initialize(bool[,] values)
        {
            _values = values;
            _graphics.Clear(_backColor);
          
            for (int i = 0; i < values.GetLength(0); i++)
            {
                for (int j = 0; j < values.GetLength(1); j++)
                {
                    Draw(i, j);
                }
            }
        }
        private void MouseDown(object sender, MouseEventArgs e)
        {
            var firstIndex = e.X / OuterWidth();
            var secondIndex = e.Y / OuterHeight();
            _values[firstIndex, secondIndex] = !_values[firstIndex, secondIndex];
            Draw(firstIndex, secondIndex);
        }
        private void Draw(int firstIndex, int secondIndex)
        {
            var x = firstIndex * OuterWidth();
            var y = secondIndex * OuterHeight();
            var rectangle = new Rectangle(x, y, _width, _height);
            if (_values[firstIndex, secondIndex])
                _graphics.FillRectangle(_onBrush, rectangle);
            else
                _graphics.FillRectangle(_offBrush, rectangle);
        }
        private int OuterWidth()
        {
            return _width + _margin;
        }
        private int OuterHeight()
        {
            return _height + _margin;
        }
        private void Draw(bool isOn, int x, int y)
        {
            var rectangle = new Rectangle(x, y, _width, _height);
            if (isOn)
                _graphics.FillRectangle(_onBrush, rectangle);
            else
                _graphics.FillRectangle(_offBrush, rectangle);
        }
        public void Dispose()
        {
            _onBrush.Dispose();
            _offBrush.Dispose();
            _graphics.Dispose();
        }
    }
