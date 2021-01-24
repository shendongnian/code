    public BitmapSource ImageSourceToBitmapSource(ImageSource imageSource)
    {
        var bitmapSource = imageSource as BitmapSource;
        if (bitmapSource == null)
        {
            // This part is only necessary if an ImageSource is not a BitmapSource,
            // which may be the case when it is a DrawingImage or a D3DImage.
            // ImageSource instances loaded from files or streams are always BitmapSources.
            //
            var rect = new Rect(0, 0, imageSource.Width, imageSource.Height);
            var renderTargetBitmap = new RenderTargetBitmap(
                (int)Math.Ceiling(rect.Width),
                (int)Math.Ceiling(rect.Height),
                96d, 96d, PixelFormats.Pbgra32);
            var drawingVisual = new DrawingVisual();
            using (var drawingContext = drawingVisual.RenderOpen())
            {
                drawingContext.DrawImage(imageSource, rect);
            }
            renderTargetBitmap.Render(drawingVisual);
            bitmapSource = renderTargetBitmap;
        }
        return bitmapSource;
    }
    public System.Drawing.Bitmap ImageSourceToBitmap(ImageSource imageSource)
    {
        return BitmapSourceToBitmap(ImageSourceToBitmapSource(imageSource));
    }
    public System.Drawing.Bitmap ImageToBitmap(Image image)
    {
        return ImageSourceToBitmap(image.Source));
    }
