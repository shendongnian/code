        public async void textRotation()
        {
            FormattedText TextFormat = new FormattedText(
                words, CultureInfo.CurrentCulture, System.Windows.FlowDirection.LeftToRight,
                new Typeface(this.Text.FontFamily, this.Text.FontStyle, this.Text.FontWeight, this.Text.FontStretch),
                this.Text.FontSize, null, null, 1);
            float TextPart = (float)TextFormat.Width / words.Length;
            for (int a = 0; a < words.Length; a++)
            {
                Text.Text = words.Substring(0, a);
                await Task.Delay(200);
                Text.ScrollToHorizontalOffset(TextPart * a);
            }
        }
