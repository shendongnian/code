    var radius = Math.Min(ActualWidth, ActualHeight) / 2;
    var centerPoint = new Point(radius, radius);
    var ellipseGeometry = new EllipseGeometry(centerPoint, radius, radius);
    var crossGeometry = new GeometryGroup();
    crossGeometry.Children.Add(new LineGeometry(
        new Point(centerPoint.X - crossSize / 2, centerPoint.Y - crossSize / 2),
        new Point(centerPoint.X + crossSize / 2, centerPoint.Y + crossSize / 2)));
    crossGeometry.Children.Add(new LineGeometry(
        new Point(centerPoint.X - crossSize / 2, centerPoint.Y + crossSize / 2),
        new Point(centerPoint.X + crossSize / 2, centerPoint.Y - crossSize / 2)));
    var crossSize = 0.8 * radius;
    var crossPen = new Pen
    {
        Thickness = 15,
        StartLineCap = PenLineCap.Round,
        EndLineCap = PenLineCap.Round
    };
    var crossOutlineGeometry = crossGeometry.GetWidenedPathGeometry(crossPen);
    var combinedGeometry = new CombinedGeometry(GeometryCombineMode.Xor,
                                                ellipseGeometry, crossOutlineGeometry);
    dc.DrawGeometry(Brushes.Gray, null, combinedGeometry);
