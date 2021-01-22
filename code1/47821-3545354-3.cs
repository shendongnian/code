        public Point _mouseClickPos;
        public bool bMoving;
        public MainPage()
        {
            InitializeComponent();
            viewboxMain.RenderTransform = new CompositeTransform();
        }
        void MouseMoveHandler(object sender, MouseEventArgs e)
        {
            
            if (bMoving)
            {
                //get current transform
                CompositeTransform transform = viewboxMain.RenderTransform as CompositeTransform;
                Point currentPos = e.GetPosition(viewboxBackground);
                transform.TranslateX += (currentPos.X - _mouseClickPos.X) ;
                transform.TranslateY += (currentPos.Y - _mouseClickPos.Y) ;
                viewboxMain.RenderTransform = transform;
                _mouseClickPos = currentPos;
            }            
        }
        void MouseClickHandler(object sender, MouseButtonEventArgs e)
        {
            _mouseClickPos = e.GetPosition(viewboxBackground);
            bMoving = true;
        }
        void MouseReleaseHandler(object sender, MouseButtonEventArgs e)
        {
            bMoving = false;
        }
