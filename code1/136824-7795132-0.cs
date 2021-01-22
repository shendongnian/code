    System.Windows.ResourceDictionary pieDataPointStyles = new ResourceDictionary();
    Style stylePie = new Style(typeof(PieDataPoint));
    stylePie.Setters.Add(new Setter(PieDataPoint.BackgroundProperty, currentBrush));
    pieDataPointStyles.Add("DataPointStyle", stylePie);
    pieSeriesPalette.Add(pieDataPointStyles);
