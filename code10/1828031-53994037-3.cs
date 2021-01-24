    private void TextBox_PreviewKeyDown(object sender, KeyRoutedEventArgs e)
    {
        bool proceed =
            (e.Key >= Windows.System.VirtualKey.Number0 && e.Key <= Windows.System.VirtualKey.Number9) ||
            (e.Key >= Windows.System.VirtualKey.NumberPad0 && e.Key <= Windows.System.VirtualKey.NumberPad9);
        e.Handled = !proceed;
    }
