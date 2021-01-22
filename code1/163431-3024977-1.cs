    public Size GetStringSize(string text)
    {
        using(Graphics g = yourPanel.CreateGraphics())
        {
            return g.MeasureString(text, yourPanel.Font);
        }
    }
