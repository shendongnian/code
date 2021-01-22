    Button b1 = new Button();
    Button b2 = new Button();
    canvas1.Children.Add(b1);
    canvas1.Children.Add(b2);
    Canvas.SetLeft(b1, 300);
    var transform1 = b1.TransformToVisual(b1.Parent as UIElement);
    var transform2 = b2.TransformToVisual(b2.Parent as UIElement);
    var lineGeometry = new LineGeometry()
    {
        StartPoint = transform1.Transform(new Point(1, b1.ActualHeight / 2.0)),
        EndPoint = transform2.Transform(new Point(b2.ActualWidth, b2.ActualHeight / 2.0))
    };
    var path = new Path()
    {
        Data = lineGeometry
    };
    canvas1.Children.Add(path);
