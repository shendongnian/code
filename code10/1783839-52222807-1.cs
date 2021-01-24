    var partiallyTransparentSolidColorBrush = new SolidColorBrush(Colors.Green);
    partiallyTransparentSolidColorBrush.Opacity = 0.25;
    var myRectangle = new Polygon
    {
        //Stroke = Brushes.Black,
        //StrokeThickness = 2,
        Fill = partiallyTransparentSolidColorBrush,
        Points =
        {
            new Point(146, 557),
            new Point(1499, 557),
            new Point(1499, 637),
            new Point(146, 637),
        }
    };
    layout.Children.Add(myRectangle);
