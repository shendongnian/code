    e.Graphics.CompositingQuality =  CompositingQuality.HighQuality;
    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
    float Direction = (Circle1Center.X > Circle2Center.X) ? -1 : 1;
    float Distance = (float)Math.Sqrt(Math.Pow(Circle1Center.X - Circle2Center.X, 2) +
                                      Math.Pow(Circle1Center.Y - Circle2Center.Y, 2));
    Distance *= Direction;
    float SinTheta = (Math.Max(Circle1Center.Y, Circle2Center.Y) -
                      Math.Min(Circle1Center.Y, Circle2Center.Y)) / Distance;
    float RotationAngle = (float)(Math.Asin(SinTheta) * (180 / Math.PI));
    using (GraphicsPath path = new GraphicsPath(FillMode.Winding))
    {
        path.AddPolygon(new[] {
            new PointF(0, -radius1),
            new PointF(0, radius1),
            new PointF(Distance, radius2),
            new PointF(Distance, -radius2),
        });
        path.AddEllipse(new RectangleF(-radius1, -radius1, 2 * radius1, 2 * radius1));
        path.AddEllipse(new RectangleF(-radius2 + (Math.Abs(Distance) * Direction),
                                       -radius2, 2 * radius2, 2 * radius2));
        e.Graphics.TranslateTransform(Circle1Center.X, Circle1Center.Y);
        e.Graphics.RotateTransform(RotationAngle);
        using (SolidBrush BlueBrush = new SolidBrush(Color.FromArgb(180, Color.SteelBlue)))
        {
            e.Graphics.FillPath(BlueBrush, path);
        }
    }
    e.Graphics.ResetTransform();
    float Direction2 = (Circle3Center.X > Circle4Center.X) ? -1 : 1;
    float Distance2 = (float)Math.Sqrt(Math.Pow(Circle3Center.X - Circle4Center.X, 2) +
                                       Math.Pow(Circle3Center.Y - Circle4Center.Y, 2));
    Distance2 *= Direction2;
    float SinTheta2 = (Math.Max(Circle3Center.Y, Circle4Center.Y) -
                       Math.Min(Circle3Center.Y, Circle4Center.Y)) / Distance2;
    float RotationAngle2 = (float)(Math.Asin(SinTheta2) * (180 / Math.PI));
    using (GraphicsPath path = new GraphicsPath(FillMode.Winding))
    {
        path.AddPolygon(new[] {
            new PointF(0, -radius1),
            new PointF(0, radius1),
            new PointF(Distance2, radius2),
            new PointF(Distance2, -radius2),
        });
        path.AddEllipse(new RectangleF(-radius1, -radius1, 2 * radius1, 2 * radius1));
        path.AddEllipse(new RectangleF(-radius2 + (Math.Abs(Distance2) * Direction2),
                        -radius2, 2 * radius2, 2 * radius2));
        e.Graphics.TranslateTransform(Circle3Center.X, Circle3Center.Y);
        e.Graphics.RotateTransform(RotationAngle2);
        using (SolidBrush GreenBrush = new SolidBrush(Color.FromArgb(200, Color.YellowGreen))) {
            e.Graphics.FillPath(GreenBrush, path);
        }
    }
