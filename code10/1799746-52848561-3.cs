    private void MainUISizeChanged(object sender, SizeChangedEventArgs e)
    {
        var points = new List<Point>
        {
            new Point(e.NewSize.Width / 2, e.NewSize.Height / 2),
            new Point(0, 0),
            new Point(0, e.NewSize.Height),
            new Point(e.NewSize.Width, e.NewSize.Height),
            new Point(e.NewSize.Width, 0)
        };
        polygons.ItemsSource = new List<PointCollection>
        {
            new PointCollection(new Point[] { points[0], points[1], points[2] }),
            new PointCollection(new Point[] { points[0], points[2], points[3] }),
            new PointCollection(new Point[] { points[0], points[3], points[4] }),
            new PointCollection(new Point[] { points[0], points[4], points[1] }),
        };
    }
