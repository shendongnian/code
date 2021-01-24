    using System.Drawing;
    using System.Drawing.Drawing2D;
    private float radius1 = 30f;
    private float radius2 = 50f;
    private PointF Circle1Center = new PointF(220, 47);
    private PointF Circle2Center = new PointF(72, 254);
    private PointF Circle3Center = new PointF(52, 58);
    private PointF Circle4Center = new PointF(217, 232);
        private void form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.CompositingQuality =  CompositingQuality.GammaCorrected;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (SolidBrush BlueBrush = new SolidBrush(Color.SteelBlue))
            using (SolidBrush GreenBrush = new SolidBrush(Color.YellowGreen))
            {
                e.Graphics.FillEllipse(BlueBrush,
                    new RectangleF(Circle1Center.X - radius1, Circle1Center.Y - radius1, 2 * radius1, 2 * radius1));
                e.Graphics.FillEllipse(BlueBrush,
                    new RectangleF(Circle2Center.X - radius2, Circle2Center.Y - radius2, 2 * radius2, 2 * radius2));
                e.Graphics.FillEllipse(GreenBrush,
                    new RectangleF(Circle3Center.X - radius1, Circle3Center.Y - radius1, 2 * radius1, 2 * radius1));
                e.Graphics.FillEllipse(GreenBrush,
                    new RectangleF(Circle4Center.X - radius2, Circle4Center.Y - radius2, 2 * radius2, 2 * radius2));
            }
            float Direction = (Circle1Center.X > Circle2Center.X) ? -1 : 1;
            float Distance = (float)Math.Sqrt(Math.Pow(Circle1Center.X - Circle2Center.X, 2) + 
                                              Math.Pow(Circle1Center.Y - Circle2Center.Y, 2));
            Distance *= Direction;
            float SinTheta = (Math.Max(Circle1Center.Y, Circle2Center.Y) - 
                              Math.Min(Circle1Center.Y, Circle2Center.Y)) / Distance;
            float RotationDirection = (Circle1Center.Y > Circle2Center.Y) ? -1 : 1;
            float RotationAngle = (float)(Math.Asin(SinTheta) * (180 / Math.PI)) * RotationDirection;
            using (GraphicsPath path = new GraphicsPath(FillMode.Winding))
            {
                path.AddPolygon(new[] {
                    new PointF(0, -radius1),
                    new PointF(0, radius1),
                    new PointF(Distance, radius2),
                    new PointF(Distance, -radius2),
                });
                e.Graphics.TranslateTransform(Circle1Center.X, Circle1Center.Y);
                e.Graphics.RotateTransform(RotationAngle);
                using (SolidBrush BlueBrush = new SolidBrush(Color.SteelBlue)) {
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
            float RotationDirection2 = (Circle3Center.Y > Circle4Center.Y) ? -1 : 1;
            float RotationAngle2 = (float)(Math.Asin(SinTheta2) * (180 / Math.PI)) * RotationDirection2;
            using (GraphicsPath path = new GraphicsPath(FillMode.Winding))
            {
                path.AddPolygon(new[] {
                    new PointF(0, -radius1),
                    new PointF(0, radius1),
                    new PointF(Distance2, radius2),
                    new PointF(Distance2, -radius2),
                });
                path.CloseAllFigures();
                e.Graphics.TranslateTransform(Circle3Center.X, Circle3Center.Y);
                e.Graphics.RotateTransform(RotationAngle2);
                using (SolidBrush GreenBrush = new SolidBrush(Color.YellowGreen)) {
                    e.Graphics.FillPath(GreenBrush, path);
                }
            }
        }
