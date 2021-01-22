    public readonly DependencyProperty WindowWidthProperty = DependencyProperty.Register("WindowWidth", typeof(Double), typeof(MainWindow), new FrameworkPropertyMetadata());
    public readonly DependencyProperty WindowHeightProperty = DependencyProperty.Register("WindowHeight", typeof(Double), typeof(MainWindow), new FrameworkPropertyMetadata());
    public double WindowWidth {
        get { return Convert.ToDouble(this.GetValue(WindowWidthProperty)); }
        set { this.SetValue(WindowWidthProperty, value); }
    }
    public double WindowHeight {
        get { return Convert.ToDouble(this.GetValue(WindowHeightProperty)); }
        set { this.SetValue(WindowHeightProperty, value); }
    }
