    private Image CreateCheckBoxGlyph(CheckBoxState state)
    {
        Bitmap Result = new Bitmap(imlCheck.ImageSize.Width, imlCheck.ImageSize.Height);
        using (Graphics g = Graphics.FromImage(Result))
        {
            Size GlyphSize = CheckBoxRenderer.GetGlyphSize(g, state);
            CheckBoxRenderer.DrawCheckBox(g,
              new Point((Result.Width - GlyphSize.Width) / 2, (Result.Height - GlyphSize.Height) / 2), state);
        }
        return Result;
    }
