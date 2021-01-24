    private void CreatePolyline()
    {
        // Initialize a new Polyline instance
        Polyline polyline = new Polyline();
        // Set polyline color
        polyline.Stroke = new SolidColorBrush(Colors.Black);
        // Set polyline width/thickness
        polyline.StrokeThickness = 10;
        // Initialize a point collection
        var points = new PointCollection();
        points.Add(new Point(20, 100));
        points.Add(new Point(35, 150));
        points.Add(new Point(60, 200));
        points.Add(new Point(90, 250));
        points.Add(new Point(40, 300));
        // Set polyline points
        polyline.Points = points;
        // Finally, add the polyline to layout
        grid.Children.Add(polyline);
    }
