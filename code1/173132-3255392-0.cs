    protected override void OnPaint(PaintEventArgs pe)
    {
        base.OnPaint(pe);
        PaintSelection(pe.Graphics);
    }
    
    private void PaintSelection(Graphics graphics)
    {
        if (isSelected)
        {
            graphics.DrawRectangle(SelectionPen, DisplayRectangle.Left, DisplayRectangle.Top, DisplayRectangle.Width - 1, DisplayRectangle.Height - 1);
        }
    }
