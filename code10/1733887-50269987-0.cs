    private void label1_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        e.Graphics.DrawEllipse(Pens.Red, 0, 0, label1.Height - 1, label1.Height - 1);
    }
