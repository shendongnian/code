    private void rtb_SelectionChanged(object sender, RoutedEventArgs e)
    {
        TextSelection ts = rtb.Selection;
        object property;
        property =  ts.GetPropertyValue(Run.FontWeightProperty);
        System.Windows.FontWeight fontWeight = property is System.Windows.FontWeight ? (FontWeight)property : FontWeights.Normal;
        
        property = ts.GetPropertyValue(Run.FontStyleProperty);
        System.Windows.FontStyle fontStyle = property is System.Windows.FontStyle ? (FontStyle)property : FontStyles.Normal;
        TextDecorationCollection textDecorations = ts.GetPropertyValue(Run.TextDecorationsProperty) as TextDecorationCollection;
        bool isUnderlined = textDecorations != null;
        double? fontSize = ts.GetPropertyValue(Run.FontSizeProperty) as double?;
        SolidColorBrush foreground = ts.GetPropertyValue(Run.ForegroundProperty) as SolidColorBrush;
        Color foregroundColor = foreground != null ? foreground.Color : Colors.Black;
        System.Diagnostics.Debug.WriteLine("fontweight:{0}, fontStyle:{1}, Underline:{2}, size:{3}, color:{4}", 
            fontWeight,
            fontStyle,
            isUnderlined,
            fontSize, 
            foregroundColor);
        if (fontSize.HasValue)
            SetToolbarFontSize(fontSize.Value);
        SetToolbarFontColor(foregroundColor);
    }
