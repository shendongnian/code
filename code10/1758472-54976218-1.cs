        private void BtnHighlight_Click(object sender, RoutedEventArgs e)
        {
            string textUpToStart = this.Rtb.TextUpTo(this.Rtb.SelectionStart);
            string textUpToEnd = this.Rtb.TextUpTo(this.Rtb.SelectionEnd);
            Debug.WriteLine($"Text up to start: '{textUpToStart}'; text up to end: '{textUpToEnd}'");
            TextRange textRange = new TextRange { StartIndex = textUpToStart.Length, Length = (textUpToEnd.Length - textUpToStart.Length) };
            TextHighlighter highlighter = new TextHighlighter() { Ranges = { textRange }, Background = new SolidColorBrush(Colors.Yellow) };
            this.Rtb.TextHighlighters.Add(highlighter);
        }
        private void BtnRemoveHighlight_Click(object sender, RoutedEventArgs e)
        {
            this.Rtb.TextHighlighters.Clear();
        }
