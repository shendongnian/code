    public BitmapSource ToBitmapSource(ImageSource imageSource)
    {
        var bitmapSource = imageSource as BitmapSource;
        if (bitmapSource == null)
        {
            var rect = new Rect(0, 0, imageSource.Width, imageSource.Height);
            var renderTargetBitmap = new RenderTargetBitmap(
                (int)Math.Ceiling(rect.Width),
                (int)Math.Ceiling(rect.Height),
                96d, 96d, PixelFormats.Pbgra32);
            var visual = new DrawingVisual();
            using (var dc = visual.RenderOpen())
            {
                dc.DrawImage(imageSource, rect);
            }
            renderTargetBitmap.Render(visual);
            bitmapSource = renderTargetBitmap;
        }
        return bitmapSource;
    }
    public System.Drawing.Bitmap ImageToBitmap(Image image)
    {
        return BitmapSourceToBitmap(ToBitmapSource(image.Source));
    }
