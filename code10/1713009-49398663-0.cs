    public static void FillEquilateralPolygon(PaintEventArgs e, int sides, Color color, double x, double y, double width, double height)
    {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        double a = width / 2;
        double b = height / 2;
        var points = new List<Point>();
        for (double pn = 0; pn < sides; pn++)
        {
            double angle = (360.0f / sides * pn) * Math.PI / 180;
            double px = a * Math.Cos(angle);
            double py = b * Math.Sin(angle);
            var point = new Point((int) (px + x), (int) (py + y));
            points.Add(point);
        }
        using (var br = new SolidBrush(color))
        {
            using (var gpath = new GraphicsPath())
            {
                gpath.AddPolygon(points.ToArray());
                e.Graphics.FillPath(br, gpath);
            }
        }
    }
