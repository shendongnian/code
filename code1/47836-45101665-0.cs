    public class ImageViewer : ContentControl
    {
        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image", typeof(BitmapSource), typeof(ImageViewer),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender |
                                                    FrameworkPropertyMetadataOptions.AffectsMeasure));
        public static readonly DependencyProperty OverlayProperty =
            DependencyProperty.Register("Overlay", typeof(BitmapSource), typeof(ImageViewer),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender |
                                                    FrameworkPropertyMetadataOptions.AffectsMeasure));
        public static readonly DependencyProperty ZoomProperty =
            DependencyProperty.Register("Zoom", typeof(double), typeof(ImageViewer),
                new FrameworkPropertyMetadata(1d, FrameworkPropertyMetadataOptions.AffectsRender |
                                                  FrameworkPropertyMetadataOptions.AffectsMeasure));
        public static readonly DependencyProperty MinZoomProperty =
            DependencyProperty.Register("MinZoom", typeof(double), typeof(ImageViewer),
                new FrameworkPropertyMetadata(1d, FrameworkPropertyMetadataOptions.AffectsRender |
                                                  FrameworkPropertyMetadataOptions.AffectsMeasure));
        public static readonly DependencyProperty MaxZoomProperty =
            DependencyProperty.Register("MaxZoom", typeof(double), typeof(ImageViewer),
                new FrameworkPropertyMetadata(5d, FrameworkPropertyMetadataOptions.AffectsRender |
                                                  FrameworkPropertyMetadataOptions.AffectsMeasure));
        public static readonly DependencyProperty TranslateProperty =
            DependencyProperty.Register("Translate", typeof(Point), typeof(ImageViewer),
                new FrameworkPropertyMetadata(new Point(0, 0), FrameworkPropertyMetadataOptions.AffectsRender |
                                                               FrameworkPropertyMetadataOptions.AffectsMeasure));
        private const float ZoomIncrement = 0.2f;
        static ImageViewer()
        {
            // Looks in the Themes/Generic.xaml to find the default style
            // Note - Do not specify x:Key in the style as the defaultstylekey
            // is the object type
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageViewer),
                new FrameworkPropertyMetadata(typeof(ImageViewer)));
        }
        /// <summary>
        /// The mouse position at the start of capture
        /// </summary>
        private Point _start;
        /// <summary>
        /// The origin of the transform at the start of capture
        /// </summary>
        private Point _origin;
        /// <summary>
        /// Capture mouse movements
        /// </summary>
        private bool _capture;
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            _start = e.GetPosition(this);
            _origin = new Point
            {
                X = Translate.X,
                Y = Translate.Y
            };
            Cursor = Cursors.Hand;
            _capture = true;
            e.Handled = true;
        }
        public void Reset()
        {
            Zoom = 1;
            Translate = new Point();
        }
        protected override void OnMouseRightButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            Reset();
        }
        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            Cursor = Cursors.Arrow;
            _capture = false;
        }
        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);
            Cursor = Cursors.Arrow;
            _capture = false;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_capture)
            {
                var position = e.GetPosition(this);
                var v = _start - position;
                Translate = new Point
                {
                    X = _origin.X - v.X,
                    Y = _origin.Y - v.Y
                };
            }
        }
        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            base.OnMouseWheel(e);
            var position = e.GetPosition(this);
            var abosuluteX = position.X * Zoom + Translate.X;
            var abosuluteY = position.Y * Zoom + Translate.Y;
            Zoom += e.Delta > 0 ? ZoomIncrement : -ZoomIncrement;
            Translate = new Point
            {
                X = abosuluteX - position.X * Zoom,
                Y = abosuluteY - position.Y * Zoom
            };
        }
        public Point Translate
        {
            get
            {
                return (Point)GetValue(TranslateProperty);
            }
            set
            {
                var width = ActualWidth * Zoom;
                var height = ActualHeight * Zoom;
                if (value.X > 0)
                {
                    value.X = 0;
                }
                if (value.X < ActualWidth - width)
                {
                    value.X = ActualWidth - width;
                }
                if (value.Y > 0)
                {
                    value.Y = 0;
                }
                if (value.Y < ActualHeight - height)
                {
                    value.Y = ActualHeight - height;
                }
                SetValue(TranslateProperty, value);
            }
        }
        public double Zoom
        {
            get
            {
                return (double)GetValue(ZoomProperty);
            }
            set
            {
                if (value <= MaxZoom && value >= MinZoom)
                {
                    SetValue(ZoomProperty, value);
                }
            }
        }
        public double MaxZoom
        {
            get
            {
                return (double)GetValue(MaxZoomProperty);
            }
            set
            {
                SetValue(MaxZoomProperty, value);
            }
        }
        public double MinZoom
        {
            get
            {
                return (double)GetValue(MinZoomProperty);
            }
            set
            {
                SetValue(MinZoomProperty, value);
            }
        }
        public BitmapSource Image
        {
            get
            {
                return (BitmapSource)GetValue(ImageProperty);
            }
            set
            {
                SetValue(ImageProperty, value);
            }
        }
    }
