    Grid grid = new Grid()
    {
        Width = 300,
        Height = 300
    };
    grid.Effect = new DropShadowEffect()
    {
        BlurRadius = 15,
        Direction = -90,
        Opacity = .2,
        RenderingBias = RenderingBias.Quality,
        ShadowDepth = 1
    };
    grid.RowDefinitions.Add(new RowDefinition());
    grid.RowDefinitions.Add(new RowDefinition());
    // ... add more rows
    // Create children:
    var border = new Border()
    {
        Background = new SolidColorBrush(Colors.White),
        CornerRadius = new CornerRadius(5)
    };
    Grid.SetRow(border, 0);
    Grid.SetRowSpan(border, 4);
    grid.Children.Add(border);
    // ... add more children
