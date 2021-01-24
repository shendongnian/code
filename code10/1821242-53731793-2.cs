    public SolidColorBrush _GridColor { get; } = new SolidColorBrush(); 
    ...
    var rect = new Rectangle
    {
        Name = $"rec{(i + 1).ToString("00")}{(j + 1).ToString("00")}",
        Height = squareSize,
        Width = squareSize,
        Fill = _ColorOff,
        Stroke = _GridColor // here
    };
    Grid.SetColumn(rect, i);
    Grid.SetRow(rect, (y - j - 1));
    grdBattleGrid.Children.Add(rect);
