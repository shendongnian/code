    var points = new List<Point>
    {
        new Point(MainUI.Width / 2, MainUI.Height / 2),
        new Point(0, 0),
        new Point(0, MainUI.Height),
        new Point(MainUI.Width, MainUI.Height),
        new Point(MainUI.Width, 0)
    };
    polygons.ItemsSource = new List<PointCollection>
    {
        new PointCollection(new Point[] { points[0], points[1], points[2] }),
        new PointCollection(new Point[] { points[0], points[2], points[3] }),
        new PointCollection(new Point[] { points[0], points[3], points[4] }),
        new PointCollection(new Point[] { points[0], points[4], points[1] }),
    };
