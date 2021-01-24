    Pen pen = new Pen(Color.LightGreen, 1);
    Brush brush = new SolidBrush(Color.White);
    string sourceDigits = "010011001";
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        CharacterRange[] charRanges = new CharacterRange[sourceDigits.Length];
        for (int chx = 0; chx < sourceDigits.Length; ++chx) {
            charRanges[chx] = new CharacterRange(chx, 1);
        }
        using (StringFormat sf = new StringFormat())
        {
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            sf.SetMeasurableCharacterRanges(charRanges);
            Region[] regions = e.Graphics.MeasureCharacterRanges(sourceDigits, Font, e.ClipRectangle, sf);
            for (int i = 0; i < regions.Length; i++) {
                RectangleF rect = regions[i].GetBounds(e.Graphics);
                e.Graphics.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
                e.Graphics.DrawString(char.ToString(sourceDigits[i]), Font, brush, rect, sf);
            }
        }
    }
