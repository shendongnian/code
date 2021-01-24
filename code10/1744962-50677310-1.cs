     public MainWindow()
        {
            InitializeComponent();
            GetPoint();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetPoint();
        }
        private void GetPoint()
        {
            var point = btnTest.TransformToAncestor(mainGrid).Transform(new Point());
            UIElement container = VisualTreeHelper.GetParent(btnTest) as UIElement;
            Point relativeLocation = btnTest.TranslatePoint(new Point(0, 0), mainGrid);
            MessageBox.Show($"X = {relativeLocation.X} Y = {relativeLocation.Y}");
        }        
