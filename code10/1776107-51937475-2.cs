        public class LedDisplayer
        {
            public LedDisplayer(Control control)
            {
                _control = control;
                _control.MouseDown += MouseDown;
                _control.Paint += Control_Paint;
    
                // width and height of your tiny boxes
                _width = 5;
                _height = 5;
    
                // margin between tiny boxes
                _margin = 1;
            }
    
            private readonly Control _control;
            private readonly int _width;
            private readonly int _height;
            private readonly int _margin;
            private bool[,] _values;
    
            // call this method first of all to initialize the Displayer
            public void Initialize(bool[,] values)
            {
                _values = values;
                _control.Invalidate();
            }
    
            private void MouseDown(object sender, MouseEventArgs e)
            {
                var firstIndex = e.X / OuterWidth();
                var secondIndex = e.Y / OuterHeight();
                _values[firstIndex, secondIndex] = !_values[firstIndex, secondIndex];
                _control.Invalidate(); // you can use other overloads of Invalidate method for the blink problem
            }
    
            private void Control_Paint(object sender, PaintEventArgs e)
            {
                if (_values == null)
                    return;
             
                e.Graphics.Clear(_control.BackColor);
                for (int i = 0; i < _values.GetLength(0); i++)
                    for (int j = 0; j < _values.GetLength(1); j++)
                        Rectangle(i, j).Paint(e.Graphics);
            }
    
            private RectangleInfo Rectangle(int firstIndex, int secondIndex)
            {
                var x = firstIndex * OuterWidth();
                var y = secondIndex * OuterHeight();
                var rectangle = new Rectangle(x, y, _width, _height);
    
                if (_values[firstIndex, secondIndex])
                    return new RectangleInfo(rectangle, Brushes.Red);
    
                return new RectangleInfo(rectangle, Brushes.Black);
            }
    
            private int OuterWidth()
            {
                return _width + _margin;
            }
    
            private int OuterHeight()
            {
                return _height + _margin;
            }
        }
        public class RectangleInfo
        {
            public RectangleInfo(Rectangle rectangle, Brush brush)
            {
                Rectangle = rectangle;
                Brush = brush;
            }
    
            public Rectangle Rectangle { get; }
            public Brush Brush { get; }
    
            public void Paint(Graphics graphics)
            {
                graphics.FillRectangle(Brush, Rectangle);
            }
        }
