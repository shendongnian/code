    class WindowsDragger
    {
        private readonly Window _window;
        private Point _dragDelta;
        public WindowsDragger(Window window)
        {
            _window = window;
            _window.MouseLeftButtonDown += MouseLeftButtonDown;
            _window.MouseLeftButtonUp += MouseLeftButtonUp;
            _window.MouseMove += MouseMove;
        }
        void MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _dragDelta = e.GetPosition(_window);
            Mouse.Capture(_window);
        }
        void MouseMove(object sender, MouseEventArgs e)
        {
            if (Equals(_window, Mouse.Captured))
            {
                var pos = _window.PointToScreen(e.GetPosition(_window));
                var verifiedPos = CoerceWindowBound(pos - _dragDelta);
                _window.Left = verifiedPos.X;
                _window.Top = verifiedPos.Y;
            }
        }
        void MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Equals(_window, Mouse.Captured))
                Mouse.Capture(null);
        }
        private Vector CoerceWindowBound(Vector newPoint)
        {
            // Snap to the current desktop border
            var screen = WpfScreen.GetScreenFrom(_window);
            var wa = screen.WorkingArea;
            if (newPoint.X < wa.Top) newPoint.X = wa.Top;
            if (newPoint.Y < wa.Left) newPoint.Y = wa.Left;
            if (_window.Width + newPoint.X > wa.Right) newPoint.X = wa.Right - _window.Width;
            if (_window.Height + newPoint.Y > wa.Bottom) newPoint.Y = wa.Bottom - _window.Height;
            return newPoint;
        }
    }
