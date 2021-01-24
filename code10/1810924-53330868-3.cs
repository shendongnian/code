    protected override void OnMouseClick(MouseEventArgs e)
    {
        base.OnMouseClick(e);
        var rect = this.RectangleToScreen(this.ClientRectangle);
        var bmp = new Bitmap(rect.Width, rect.Height);
        Graphics memgr = Graphics.FromImage(bmp);
        mypaint(memgr);
        bmp.Save(@"c:\test\test.bmp");
    }
