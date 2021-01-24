    public MainWindow()
    {
        InitializeComponent();
        SetSize(40, 40);
    }
    private void SetSize(int x, int y)
    {
        grid.Children.Clear();
        grid.Columns = x;
        for (int i = 0; i < x * y; i++)
        {
            grid.Children.Add(new Button
            {
                BorderThickness = new Thickness(1),
                BorderBrush = Brushes.Gray,
                Background = Brushes.DarkGray,
                Foreground = Brushes.DarkGray,
                Content = ""
            });
        }
    }
