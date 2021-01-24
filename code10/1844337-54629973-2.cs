    using (Bitmap fullBitmap = new Bitmap(this.Width, this.Height, PixelFormat.Format32bppArgb))
    {
        Point p = this.PointToScreen(Point.Empty);
        Rectangle clientRect = new Rectangle(new Point(p.X - this.Bounds.X, p.Y - this.Bounds.Y), this.ClientSize);
        this.DrawToBitmap(fullBitmap, new Rectangle(Point.Empty, this.Size));
        using (Bitmap clientBitmap = fullBitmap.Clone(clientRect, PixelFormat.Format32bppArgb))
        {
            clientBitmap.Save(@"[Some File Path].png", ImageFormat.Png);
            //Or, return clientBitmap;
        }
    }
