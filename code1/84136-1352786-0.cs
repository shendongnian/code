    protected override void OnPaint(PaintEventArgs e)
    {
        TextRenderer.DrawText(e.Graphics, Text, Font, new Rectangle(0, 0, Width, Height), ForeColor);
    }
    public override Size GetPreferredSize(Size proposedSize)
    {
        return TextRenderer.MeasureText(Text, Font);
    }
