    public void Render(Graphics g, int dx, int dy)
    {
        g.DrawRectangle(
            Pens.DarkCyan,
            Position.Item1 + dx - Dimension.Item1 / 2,
            Position.Item2 + dy - Dimension.Item2 / 2,
            Dimension.Item1,
            Dimension.Item2);
    }
