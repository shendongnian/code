    protected override void OnPaint(PaintEventArgs e)
    {
        int x = ClientSize.Width / 2;
        int y = ClientSize.Height / 2;
        // Don't create your own `Graphics` object but use the one provided in the event argument
        e.Graphics.DrawRectangle(
            Pens.DarkCyan,
            Position.Item1 + x - Dimension.Item1 / 2,
            Position.Item2 + y - Dimension.Item2 / 2,
            Dimension.Item1,
            Dimension.Item2);
    }
