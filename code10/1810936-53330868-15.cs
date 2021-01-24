    protected override void OnMouseClick(MouseEventArgs e)
    {
        base.OnMouseClick(e);
        var rect = this.RectangleToScreen(this.ClientRectangle);
        using (var bmp = new Bitmap(rect.Width, rect.Height))
        {
            do_all_paintings(Graphics.FromImage(bmp));
            bmp.Save(@"c:\test\test.bmp");
        }
    }
