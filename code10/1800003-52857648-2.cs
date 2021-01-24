    public MainWindow()
    {
        InitializeComponent();
        s.Width = 20;
        s.Height = 20;
        s.Fill = Brushes.Black;
        Canvas.SetLeft(s, 20);
        map.Children.Add(s);
        var animation = new DoubleAnimation
        {
            By = 20,
            Duration = TimeSpan.FromSeconds(1),
            IsCumulative = true,
            RepeatBehavior = RepeatBehavior.Forever
        };
        s.BeginAnimation(Canvas.LeftProperty, animation);
    }
