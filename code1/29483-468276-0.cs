    var transform1 = shape1.TransformToVisual(shape1.Parent as UIElement);
    var transform2 = shape2.TransformToVisual(shape2.Parent as UIElement);
    
    var lineGeometry = new LineGeometry()
    {
      StartPoint = transform1.Transform(new Point(shape1.ActualWidth / 2, shape1.ActualHeight / 2.0)),
      EndPoint = transform2.Transform(new Point(shape2.ActualWidth / 2.0,    shape2.ActualHeight / 2.0))
    };
    
    var path = new Path()
    {
    Data = lineGeometry
    };
