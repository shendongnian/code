    protected override void OnMouseClick(MouseEventArgs e)
    {
        base.OnMouseClick(e);
        //get the screen coordinates for this window
        var rect = this.RectangleToScreen(this.ClientRectangle);
        //copy bits from screen to bitmap
        using (var bmp = new Bitmap(rect.Width, rect.Height))
        {
            var gr = Graphics.FromImage(bmp);
            gr.CopyFromScreen(rect.Left, rect.Top, 0, 0, rect.Size);
            //save to file
            bmp.Save(@"c:\test\test.bmp");
        }
    }
