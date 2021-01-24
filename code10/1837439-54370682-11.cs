    public RenderTargetBitmap GetImage(FrameworkElement element)
    {
        element.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
        element.Arrange(new Rect(element.DesiredSize));
        Size size = element.DesiredSize;
        if (size.IsEmpty)
            return null;
        RenderTargetBitmap result = new RenderTargetBitmap((int)size.Width, (int)size.Height, 96, 96, PixelFormats.Pbgra32);
        DrawingVisual drawingvisual = new DrawingVisual();
        using (DrawingContext context = drawingvisual.RenderOpen())
        {
            context.DrawRectangle(new VisualBrush(element), null, new Rect(new Point(), size));
        }
        result.Render(drawingvisual);
        return result;
    }
