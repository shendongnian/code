    // Draw connecting lines
    var geo = new StreamGeometry();
    using(geoContext = geo.Open())
    {
      geoContext.StartFigure(stylusPoints[0], false, false);
      geoContext.PolyLineTo(stylusPoints.Skip(1).Cast<Point>(), true, false);
    }
    drawingContext.DrawGeometry(null, connectingLinePen, geo);
    // Draw ellipses
    for(int i = 1; i < stylusPoints.Count; i++)
    {
      ... etc ...
