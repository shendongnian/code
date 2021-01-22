    public void DrawString(string text, IFont font, Point point)
    {
        System.Drawing.Font f = (Font)font.Font;
        graphics.DrawString(text, f, Brushes.Block, point);
    }
