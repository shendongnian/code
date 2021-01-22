    protected override void OnPaint(PaintEventArgs e) {
        var img = Properties.Resources.Chrysanthemum;
        e.Graphics.DrawImage(img, 0, 0);
        e.Graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
        using (var br = new SolidBrush(Color.FromArgb(0, 255, 255, 255))) {
            e.Graphics.FillRectangle(br, new Rectangle(50, 50, 100, 100));
        }
    }
