    public class Viewport : ContentControl
    {
        private bool _capture;
        private FrameworkElement _content;
        private Matrix _matrix;
        private Point _origin;
        public static readonly DependencyProperty MaxZoomProperty =
            DependencyProperty.Register(
                nameof(MaxZoom),
                typeof(double),
                typeof(Viewport),
                new PropertyMetadata(0d));
        public static readonly DependencyProperty MinZoomProperty =
            DependencyProperty.Register(
                nameof(MinZoom),
                typeof(double),
                typeof(Viewport),
                new PropertyMetadata(0d));
        public static readonly DependencyProperty ZoomSpeedProperty =
            DependencyProperty.Register(
                nameof(ZoomSpeed),
                typeof(float),
                typeof(Viewport),
                new PropertyMetadata(0f));
        public static readonly DependencyProperty ZoomXProperty =
            DependencyProperty.Register(
                nameof(ZoomX),
                typeof(double),
                typeof(Viewport),
                new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public static readonly DependencyProperty ZoomYProperty =
            DependencyProperty.Register(
                nameof(ZoomY),
                typeof(double),
                typeof(Viewport),
                new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public static readonly DependencyProperty OffsetXProperty =
            DependencyProperty.Register(
                nameof(OffsetX),
                typeof(double),
                typeof(Viewport),
                new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public static readonly DependencyProperty OffsetYProperty =
            DependencyProperty.Register(
                nameof(OffsetY),
                typeof(double),
                typeof(Viewport),
                new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public static readonly DependencyProperty BoundsProperty =
            DependencyProperty.Register(
                nameof(Bounds),
                typeof(Rect),
                typeof(Viewport),
                new FrameworkPropertyMetadata(default(Rect), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public Rect Bounds
        {
            get => (Rect) GetValue(BoundsProperty);
            set => SetValue(BoundsProperty, value);
        }
        public double MaxZoom
        {
            get => (double) GetValue(MaxZoomProperty);
            set => SetValue(MaxZoomProperty, value);
        }
        public double MinZoom
        {
            get => (double) GetValue(MinZoomProperty);
            set => SetValue(MinZoomProperty, value);
        }
        public double OffsetX
        {
            get => (double) GetValue(OffsetXProperty);
            set => SetValue(OffsetXProperty, value);
        }
        public double OffsetY
        {
            get => (double) GetValue(OffsetYProperty);
            set => SetValue(OffsetYProperty, value);
        }
        public float ZoomSpeed
        {
            get => (float) GetValue(ZoomSpeedProperty);
            set => SetValue(ZoomSpeedProperty, value);
        }
        public double ZoomX
        {
            get => (double) GetValue(ZoomXProperty);
            set => SetValue(ZoomXProperty, value);
        }
        public double ZoomY
        {
            get => (double) GetValue(ZoomYProperty);
            set => SetValue(ZoomYProperty, value);
        }
        public Viewport()
        {
            DefaultStyleKey = typeof(Viewport);
            Loaded += OnLoaded;
            Unloaded += OnUnloaded;
        }
        private void Arrange(Size desired, Size render)
        {
            _matrix = Matrix.Identity;
            var zx = desired.Width / render.Width;
            var zy = desired.Height / render.Height;
            var cx = render.Width < desired.Width ? render.Width / 2.0 : 0.0;
            var cy = render.Height < desired.Height ? render.Height / 2.0 : 0.0;
            var zoom = Math.Min(zx, zy);
            if (render.Width > desired.Width &&
                render.Height > desired.Height)
            {
                cx = (desired.Width - (render.Width * zoom)) / 2.0;
                cy = (desired.Height - (render.Height * zoom)) / 2.0;
                _matrix = new Matrix(zoom, 0d, 0d, zoom, cx, cy);
            }
            else
            {
                _matrix.ScaleAt(zoom, zoom, cx, cy);
            }
        }
        private void Attach(FrameworkElement content)
        {
            content.MouseMove += OnMouseMove;
            content.MouseLeave += OnMouseLeave;
            content.MouseWheel += OnMouseWheel;
            content.MouseLeftButtonDown += OnMouseLeftButtonDown;
            content.MouseLeftButtonUp += OnMouseLeftButtonUp;
            content.SizeChanged += OnSizeChanged;
            content.MouseRightButtonDown += OnMouseRightButtonDown;
        }
        private void ChangeContent(FrameworkElement content)
        {
            if (content != null && !Equals(content, _content))
            {
                if (_content != null)
                {
                    Detatch();
                }
                Attach(content);
                _content = content;
            }
        }
        private double Constrain(double value, double min, double max)
        {
            if (min > max)
            {
                min = max;
            }
            if (value <= min)
            {
                return min;
            }
            if (value >= max)
            {
                return max;
            }
            return value;
        }
        private void Constrain()
        {
            var x = Constrain(_matrix.OffsetX, _content.ActualWidth - _content.ActualWidth * _matrix.M11, 0);
            var y = Constrain(_matrix.OffsetY, _content.ActualHeight - _content.ActualHeight * _matrix.M22, 0);
            _matrix = new Matrix(_matrix.M11, 0d, 0d, _matrix.M22, x, y);
        }
        private void Detatch()
        {
            _content.MouseMove -= OnMouseMove;
            _content.MouseLeave -= OnMouseLeave;
            _content.MouseWheel -= OnMouseWheel;
            _content.MouseLeftButtonDown -= OnMouseLeftButtonDown;
            _content.MouseLeftButtonUp -= OnMouseLeftButtonUp;
            _content.SizeChanged -= OnSizeChanged;
            _content.MouseRightButtonDown -= OnMouseRightButtonDown;
        }
        private void Invalidate()
        {
            if (_content != null)
            {
                Constrain();
                _content.RenderTransformOrigin = new Point(0, 0);
                _content.RenderTransform = new MatrixTransform(_matrix);
                _content.InvalidateVisual();
                ZoomX = _matrix.M11;
                ZoomY = _matrix.M22;
                OffsetX = _matrix.OffsetX;
                OffsetY = _matrix.OffsetY;
                var rect = new Rect
                {
                    X = OffsetX * -1,
                    Y = OffsetY * -1,
                    Width = ActualWidth,
                    Height = ActualHeight
                };
                Bounds = rect;
            }
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _matrix = Matrix.Identity;
        }
        protected override void OnContentChanged(object oldContent, object newContent)
        {
            base.OnContentChanged(oldContent, newContent);
            if (Content is FrameworkElement element)
            {
                ChangeContent(element);
            }
        }
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (Content is FrameworkElement element)
            {
                ChangeContent(element);
            }
            SizeChanged += OnSizeChanged;
            Loaded -= OnLoaded;
        }
        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            if (_capture)
            {
                Released();
            }
        }
        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (IsEnabled && !_capture)
            {
                Pressed(e.GetPosition(this));
            }
        }
        private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (IsEnabled && _capture)
            {
                Released();
            }
        }
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (IsEnabled && _capture)
            {
                var position = e.GetPosition(this);
                var point = new Point
                {
                    X = position.X - _origin.X,
                    Y = position.Y - _origin.Y
                };
                var delta = point;
                _origin = position;
                _matrix.Translate(delta.X, delta.Y);
                Invalidate();
            }
        }
        private void OnMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (IsEnabled)
            {
                Reset();
            }
        }
        private void OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (IsEnabled)
            {
                var scale = e.Delta > 0 ? ZoomSpeed : 1 / ZoomSpeed;
                var position = e.GetPosition(_content);
                var x = Constrain(scale, MinZoom / _matrix.M11, MaxZoom / _matrix.M11);
                var y = Constrain(scale, MinZoom / _matrix.M22, MaxZoom / _matrix.M22);
                _matrix.ScaleAtPrepend(x, y, position.X, position.Y);
                ZoomX = _matrix.M11;
                ZoomY = _matrix.M22;
                Invalidate();
            }
        }
        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (_content?.IsMeasureValid ?? false)
            {
                Arrange(_content.DesiredSize, _content.RenderSize);
                Invalidate();
            }
        }
        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            Detatch();
            SizeChanged -= OnSizeChanged;
            Unloaded -= OnUnloaded;
        }
        private void Pressed(Point position)
        {
            if (IsEnabled)
            {
                _content.Cursor = Cursors.Hand;
                _origin = position;
                _capture = true;
            }
        }
        private void Released()
        {
            if (IsEnabled)
            {
                _content.Cursor = null;
                _capture = false;
            }
        }
        private void Reset()
        {
            _matrix = Matrix.Identity;
            if (_content != null)
            {
                Arrange(_content.DesiredSize, _content.RenderSize);
            }
            Invalidate();
        }
    }
