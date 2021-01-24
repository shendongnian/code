    protected override void OnPaint(PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        using (var path1 = new GraphicsPath())
        {
            path1.AddArc(new Rectangle(100, 100, 200, 200), -90, 90);
            using (var pen1 = new Pen(Color.Red, 3))
                e.Graphics.DrawPath(pen1, path1);
            using (var path2 = MirrorLeft(path1))
            using (var pen2 = new Pen(Color.Green, 3))
                e.Graphics.DrawPath(pen2, path2);
            using (var path3 = MirrorRight(path1))
            using (var pen3 = new Pen(Color.Blue, 3))
                e.Graphics.DrawPath(pen3, path3);
        }
        base.OnPaint(e);
    }
