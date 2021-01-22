        RectangleF rectF = new RectangleF(0, 0, 40, 40);
        Bitmap bitmap = new Bitmap(40, 40, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
        Graphics g = Graphics.FromImage(bitmap);
        g.FillRectangle(System.Drawing.Brushes.White, 0, 0, 40, 40);
        g.DrawString("5", new Font("Arial", 25), System.Drawing.Brushes.Black, new PointF(0, 0));
        IntPtr hBitmap = bitmap.GetHbitmap();
        ImageSource wpfBitmap =
            Imaging.CreateBitmapSourceFromHBitmap(
      hBitmap, IntPtr.Zero, Int32Rect.Empty,
      BitmapSizeOptions.FromEmptyOptions());
        TaskbarItemInfo.Overlay = wpfBitmap;
