    public Size GetStringSize(string text)
    {
        using(Graphics g = yourPanel.CreateGraphics())
        {
            return g.MeasureString(text, yourPanel.Font);
            // OR, to measure the height only and wrap to the current width:
            return g.MeasureString(text, yourPanel.Font, yourPanel.Width);
        }
    }
