    private void pictureBox2_Paint(object sender, PaintEventArgs e)
    {
        GraphicsPath gp0 = new GraphicsPath();
        GraphicsPath gp1 = new GraphicsPath();
        GraphicsPath gp2 = new GraphicsPath();
        GraphicsPath gp3 = new GraphicsPath();
        GraphicsPath gp4 = new GraphicsPath();
        gp0.AddEllipse(11, 11, 333, 333);
        gp1.AddEllipse(55, 55, 55, 55);
        gp2.AddEllipse(222, 55, 66, 66);
        gp3.AddEllipse(55, 222, 99, 222);
        gp4.AddLine(66, 123, 234, 77);
        using (Pen pen = new Pen(Color.Empty, 12f))
        gp4.Widen(pen);
        gp0.AddPath(gp1, true);
        gp0.AddPath(gp2, true);
        gp0.AddPath(gp3, true);
        gp0.AddPath(gp4, true);
        gp0.FillMode = FillMode.Alternate;
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        e.Graphics.FillPath(Brushes.Goldenrod, gp0);
    }
