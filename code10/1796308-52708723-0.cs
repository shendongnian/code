        Ellipse e1 = new Ellipse();
        DispatcherTimer t1;
        TimeSpan o = new TimeSpan(0, 0, 0, 0, 10);
        Key Direction { get; set; } = Key.Space;
        public MainWindow()
        {
            InitializeComponent();
            t1 = new DispatcherTimer();
            t1.Interval = o;
            t1.Tick += T1_Tick;
            myCanvas.Children.Add(e1);
            e1.Fill = new SolidColorBrush(Colors.Black);
            Canvas.SetLeft(e1, 250);
            Canvas.SetTop(e1, 250);
            e1.Height = 75;
            e1.Width = 75;
            this.KeyDown += MainWindow_KeyDown;
            t1.Start();
        }
        private void T1_Tick(object sender, EventArgs e)
        {
            double X = Canvas.GetLeft(e1);
            double Y = Canvas.GetTop(e1);
            if (Direction == Key.Up) // Up
            {
                if (Y > 0)
                    Canvas.SetTop(e1, Y - 10);
            }
            else if (Direction == Key.Left) // Left
            {
                if (X > 0)
                    Canvas.SetLeft(e1, X - 10);
            }
            else if (Direction == Key.Right) // Right
            {
                if (X + e1.ActualWidth < myCanvas.ActualWidth)
                    Canvas.SetLeft(e1, X + 10);
            }
            else if (Direction == Key.Down) // Down
            {
                if (Y + e1.ActualHeight < myCanvas.ActualHeight)
                    Canvas.SetTop(e1, Y + 10);
            }
        }
        //MainWindow KeyDown
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            Direction = e.Key;
        }
 
