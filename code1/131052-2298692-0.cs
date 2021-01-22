    Rectangle bounds = this.Bounds;
    using (Bitmap ss = new Bitmap(bounds.Width, bounds.Height))
    using (Graphics g = Graphics.FromImage(ss))
    {
        this.Opacity = 0;
        g.CopyFromScreen(this.Location, Point.Empty, bounds.Size);
     
        using(MemoryStream ms = new MemoryStream()) {
            ss.Save(ms, ImageFormat.Png);
            this.Opacity = 100;
            this.BackgroundImage = new Bitmap(ms);
        }
        
        g.Dispose();
    }
