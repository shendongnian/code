    private void RichTxt_TextChanged(object sender, TextChangedEventArgs e)
    {
        string text = new TextRange(richTxt.Document.ContentStart, richTxt.Document.ContentEnd).Text;
        FormattedText ft = new FormattedText(text, System.Globalization.CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(richTxt.FontFamily, richTxt.FontStyle, richTxt.FontWeight, richTxt.FontStretch), richTxt.FontSize, Brushes.Black);
        richTxt.Document.PageWidth = ft.Width + 12;
        richTxt.HorizontalScrollBarVisibility = (richTxt.Width < ft.Width + 12) ? ScrollBarVisibility.Visible : ScrollBarVisibility.Hidden;
    }
