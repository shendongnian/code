    public void drawString(string text, IMyFont font, Point point)
    {
        using(System.Drawing.Font theFont = GetFont(font))
        {
            theGraphics.DrawString(word.text, theFont, Brushes.Block, point);
        }
        // etc
    }
