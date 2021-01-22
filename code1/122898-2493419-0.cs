    /// <summary>
    /// Formats code blocks.
    /// </summary>
    private void OnCodeBlockClick(object sender, RoutedEventArgs e)
    {
        var selection = TextBox.Selection;
        var textRange = new TextRange(selection.Start, selection.End);
        textRange.ApplyPropertyValue(TextElement.FontFamilyProperty, "Consolas");
        textRange.ApplyPropertyValue(TextElement.FontSizeProperty, 10D );
        textRange.ApplyPropertyValue(TextElement.BackgroundProperty, "LightSteelBlue");
    }
