    var geometry = new StreamGeometry();
    using (var geometryContext = geometry.Open())
    {
        var lastPoint = stroke.StylusPoints.Last();
        geometryContext.BeginFigure(new Point(lastPoint.X, lastPoint.Y), true, true);
        foreach (var point in stroke.StylusPoints)
        {
            geometryContext.LineTo(new Point(point.X, point.Y), true, true);
        }
    }
    geometry.Freeze();
    _revealShapes.Children.Add(geometry);
