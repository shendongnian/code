    private void writeToLog(String text, SolidColorBrush color)
    {
        TextRange tr = new TextRange(logTextBox.Document.ContentEnd, logTextBox.Document.ContentEnd);
        tr.Text = text;
        tr.ApplyPropertyValue(TextElement.ForegroundProperty, color);
    }
