        public partial class UserControlDraggable : UserControl
    {
        public UserControlDraggable()
        {
            InitializeComponent();
            MouseLeftButtonDown += new MouseButtonEventHandler(Control_MouseLeftButtonDown);
            MouseLeftButtonUp += new MouseButtonEventHandler(Control_MouseLeftButtonUp);
            MouseMove += new MouseEventHandler(Control_MouseMove);
        }
        private void Control_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _isDragging = true;
            _mouseLocationWithinMe = e.GetPosition(this);
            CaptureMouse();
        }
        private void Control_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _isDragging = false;
            this.ReleaseMouseCapture();
        }
        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                var mouseWithinParent = e.GetPosition(Parent as UIElement);
                Canvas.SetLeft(this, mouseWithinParent.X - _mouseLocationWithinMe.X);
                Canvas.SetTop(this, mouseWithinParent.Y - _mouseLocationWithinMe.Y);
            }
        }
        protected bool _isDragging;
        Point _mouseLocationWithinMe;
    }
