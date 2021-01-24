    public async void textRotation()
    {
        var textFormat = new FormattedText(
            words, CultureInfo.CurrentCulture, System.Windows.FlowDirection.LeftToRight,
            new Typeface(this.Text.FontFamily, this.Text.FontStyle, this.Text.FontWeight, this.Text.FontStretch),
            this.Text.FontSize, null, null, 1);
        float textPart = (float)textFormat.Width / words.Length;
        for (int i = 0; i < words.Length; i++)
        {
            Text.Text = words.Substring(0, i);
            await Task.Delay(200);
            Text.ScrollToHorizontalOffset(textPart * i);
        }
    }
