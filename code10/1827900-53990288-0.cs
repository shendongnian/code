    public async void textRotation()
    {
        float TextPart = TextRenderer.MeasureText(words, new Font(Text.FontFamily.Source, (float)Text.FontSize)).Width / words.Length;
        for (int a = 0; a < words.Length; a++)
        {
            Text.Text = words.Substring(0, a);
            await Task.Delay(100);
            Text.ScrollToHorizontalOffset(TextPart * a);
        }
    }
