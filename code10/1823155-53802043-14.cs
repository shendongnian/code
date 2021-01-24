    ZoomFactor zoomHelper = new ZoomFactor()
    Bitmap originalBitmap;
    RectangleF currentSelection = [Current Selection Rectangle];
    RectangleF bitmapRect = zoomHelper.TranslateZoomSelection(currentSelection, [Container].Size, originalBitmap.Size);
    using (Bitmap croppedBitmap = new Bitmap((int)bitmapRect.Width, (int)bitmapRect.Height, originalBitmap.PixelFormat))
    using (Graphics g = Graphics.FromImage(croppedBitmap))
    {
        g.DrawImage(originalBitmap, new Rectangle(Point.Empty, Size.Round(bitmapRect.Size)), 
                    bitmapRect, GraphicsUnit.Pixel);
        [Container].Image = (Bitmap)croppedBitmap.Clone();
    }
