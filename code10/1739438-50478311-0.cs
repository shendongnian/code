    PointF PivotPoint = new PointF(100F, 100F);
    PointF RotatingPoint = new PointF(50F, 100F);
    double RotationSpin = 0D;
    private PointF RotatePoint(PointF point, PointF pivot, double radians)
    {
        var cosTheta = Math.Cos(radians);
        var sinTheta = Math.Sin(radians);
        var x = (cosTheta * (point.X - pivot.X) - sinTheta * (point.Y - pivot.Y) + pivot.X);
        var y = (sinTheta * (point.X - pivot.X) + cosTheta * (point.Y - pivot.Y) + pivot.Y);
        return new PointF((float)x, (float)y);
    }
    private void RotateTimerTick(object sender, EventArgs e)
    {
        RotationSpin += .5;
        
        if (RotationSpin > 90) RotationSpin = 0;
        RotatingPoint = RotatePoint(RotatingPoint, PivotPoint, (Math.PI / 180f) * RotationSpin);
        Panel1.Invalidate(new Rectangle(new Point(50,50), new Size(110, 110)));
    }
    private void Panel1_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        e.Graphics.FillEllipse(Brushes.White, new RectangleF(100, 100, 8, 8));
        e.Graphics.FillEllipse(Brushes.Yellow, new RectangleF(RotatingPoint, new SizeF(8, 8)));
    }
