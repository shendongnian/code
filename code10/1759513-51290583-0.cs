    public BitmapSource GetBitmapSource(Image image)
    {
        var bitmapSource = image.Source as BitmapSource;
        if (bitmapSource == null)
        {
            var renderTargetBitmap = new RenderTargetBitmap(
                (int)Math.Ceiling(image.Source.Width),
                (int)Math.Ceiling(image.Source.Height),
                96d, 96d,
                PixelFormats.Pbgra32);
            renderTargetBitmap.Render(image);
            bitmapSource = renderTargetBitmap;
        }
        return bitmapSource;
    }
    public System.Drawing.Bitmap ImageToBitmap(Image image)
    {
        return BitmapSourceToBitmap(GetBitmapSource(image));
    }
