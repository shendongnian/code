    ZoomFactor ZoomHelper = new ZoomFactor()
    Bitmap originalBitmap;
    RectangleF CurrentSelection = [Current Selection Rectangle];
    RectangleF BitmapRect = ZoomHelper.TranslateZoomSelection(CurrentSelection, [Container].Size, originalBitmap.Size);
    using (Bitmap CroppedBitmap = new Bitmap((int)BitmapRect.Width, (int)BitmapRect.Height, originalBitmap.PixelFormat))
    using (Graphics g = Graphics.FromImage(CroppedBitmap))
    {
        g.DrawImage(originalBitmap, new Rectangle(Point.Empty, Size.Round(BitmapRect.Size)), 
                    BitmapRect, GraphicsUnit.Pixel);
        [Container].Image = (Bitmap)CroppedBitmap.Clone();
    }
