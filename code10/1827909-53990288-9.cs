    public async void textRotation()
    {
        float textPart = TextRenderer.MeasureText(words, new Font(Text.FontFamily.Source, (float)Text.FontSize)).Width / words.Length;
        for (int i = 0; i < words.Length; i++)
        {
            Text.Text = words.Substring(0, i);
            await Task.Delay(100);
            Text.ScrollToHorizontalOffset(textPart * i);
        }
    }
