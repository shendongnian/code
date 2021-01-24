    private void AddInvisibleDotsAtCorners()
    {
        var inkStrokeBuilder = new InkStrokeBuilder();
        var stroke1 = inkStrokeBuilder.CreateStrokeFromInkPoints(
            new InkPoint[] 
            {
                new InkPoint(new Point(0, 0), 0.0f)
            }, System.Numerics.Matrix3x2.Identity);
        var stroke2 = inkStrokeBuilder.CreateStrokeFromInkPoints(
            new InkPoint[]
            {
                new InkPoint(new Point(inkCanvas.ActualWidth, inkCanvas.ActualHeight), 0.0f)
            }, System.Numerics.Matrix3x2.Identity);
        inkCanvas.InkPresenter.StrokeContainer.AddStroke(stroke1);
        inkCanvas.InkPresenter.StrokeContainer.AddStroke(stroke2);
    }
