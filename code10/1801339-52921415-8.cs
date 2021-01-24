    using System.Drawing;
    using System.Drawing.Drawing2D;
    private float Radius1 = 30f;
    private float Radius2 = 50f;
    private PointF Circle1Center = new PointF(220, 47);
    private PointF Circle2Center = new PointF(72, 254);
    private PointF Circle3Center = new PointF(52, 58);
    private PointF Circle4Center = new PointF(217, 232);
    private void form1_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.CompositingQuality =  CompositingQuality.GammaCorrected;
        e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        DrawLinkedCircles(Circle1Center, Circle2Center, Radius1, Radius2, Color.FromArgb(200, Color.YellowGreen), e.Graphics);
        DrawLinkedCircles(Circle3Center, Circle4Center, Radius1, Radius2, Color.FromArgb(200, Color.SteelBlue), e.Graphics);
        //OR, passing a RectangleF structure
        //RectangleF Circle1 = new RectangleF(Circle1Center.X - Radius1, Circle1Center.Y - Radius1, Radius1 * 2, Radius1 * 2);
        //RectangleF Circle2 = new RectangleF(Circle2Center.X - Radius2, Circle2Center.Y - Radius2, Radius2 * 2, Radius2 * 2);
        //DrawLinkedCircles(Circle1, Circle2, Color.FromArgb(200, Color.YellowGreen), e.Graphics);
    }
