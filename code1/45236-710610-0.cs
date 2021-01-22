    protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
    {
        base.OnRenderItemCheck(e);
        if (e.Item.Selected)
        {
            Rectangle rect = new Rectangle(3, 1, 20, 20);
            Rectangle rect2 = new Rectangle(4, 2, 18, 18);
            SolidBrush b = new SolidBrush(Color.FromArgb(49, 106, 197));
            SolidBrush b2 = new SolidBrush(Color.Orange);
    
            e.Graphics.FillRectangle(b, rect);
            e.Graphics.FillRectangle(b2, rect2);
            e.Graphics.DrawImage(e.Image, new Point(5, 3));
        }
        else
        {
            Rectangle rect = new Rectangle(3, 1, 20, 20);
            Rectangle rect2 = new Rectangle(4, 2, 18, 18);
            SolidBrush b = new SolidBrush(Color.FromArgb(49, 106, 197));
            SolidBrush b2 = new SolidBrush(Color.Orange);
    
            e.Graphics.FillRectangle(b, rect);
            e.Graphics.FillRectangle(b2, rect2);
            e.Graphics.DrawImage(e.Image, new Point(5, 3));
        }
    }
 
