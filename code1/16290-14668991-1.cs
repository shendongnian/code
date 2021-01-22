    if (e.Node.ImageIndex >= e.Node.TreeView.ImageList.Images.Count) // if there is no image
    {
        int imagewidths = e.Node.TreeView.ImageList.ImageSize.Width;
        int textheight = TextRenderer.MeasureText(e.Node.Text, e.Node.NodeFont).Height;
        int x = e.Node.Bounds.Left - 3 - imagewidths / 2;
        int y = (e.Bounds.Top + e.Bounds.Bottom) / 2+1;
        Point point = new Point(x - imagewidths/2, y - textheight/2); // the new location for the text to be drawn
        TextRenderer.DrawText(e.Graphics, e.Node.Text, e.Node.NodeFont, point, e.Node.ForeColor);
    }
    else // drawn at the default location
        TextRenderer.DrawText(e.Graphics, e.Node.Text, e.Node.TreeView.Font, e.Bounds, e.Node.ForeColor);
