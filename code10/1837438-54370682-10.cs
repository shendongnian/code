    public RenderTargetBitmap GetImage(FrameworkElement element)
    {
        Size size = new Size(element.ActualWidth, element.ActualHeight);
        if (size.IsEmpty)
            return null;
        element.Measure(size);
        element.Arrange(new Rect(size));
        RenderTargetBitmap result = new RenderTargetBitmap((int)size.Width, (int)size.Height, 96, 96, PixelFormats.Pbgra32);
        DrawingVisual drawingvisual = new DrawingVisual();
        using (DrawingContext context = drawingvisual.RenderOpen())
        {
            context.DrawRectangle(new VisualBrush(element), null, new Rect(new Point(), size));
        }
        result.Render(drawingvisual);
        return result;
    }
