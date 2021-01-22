    var geometry = new PathGeometry();
    geometry.Figures.Add(new PathFigure(new Point(10, 10), new PathSegment[] { new LineSegment(new Point(10, 20), true), new LineSegment(new Point(20, 20), true) }, true));
    geometry.Transform = new ScaleTransform(2, 2);
    var transformedGeometry = new PathGeometry ();
    // this copies the transformed figures one by one into the new geometry
    transformedGeometry.AddGeometry (geometry); 
