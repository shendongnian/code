    // this is the color of bar series
    if (chartSeries.Key.ColorHex != null)
    {
        Style style = new Style(typeof(Border));
        style.Setters.Add(new Setter(Border.BackgroundProperty, (SolidColorBrush)(new BrushConverter().ConvertFrom(chartSeries.Key.ColorHex))));
        style.Setters.Add(new Setter(Border.BorderThicknessProperty, new Thickness(2.0)));
        barSerie.DefaultVisualStyle = style;
    }
