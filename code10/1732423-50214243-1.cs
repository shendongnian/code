    private void chart1_PostPaint(object sender, ChartPaintEventArgs e)
    {
        // add references..
        ..
        // then use values to calulate pixel coordinates..
        int py1 = (int)ay.ValueToPixelPosition(ay.Minimum + ay.IntervalOffset);
        int py2 = (int)ay.ValueToPixelPosition(ay.Maximum);
        int px  = (int)ax.ValueToPixelPosition(ax.Maximum -  ax.Minimum);
        // blue to make it stand out
        e.ChartGraphics.Graphics.DrawLine(Pens.Blue, px, py1, px, py2);
    }
