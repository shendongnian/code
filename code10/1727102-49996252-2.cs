    private void chart_PrePaint(object sender, ChartPaintEventArgs e)
    {
        // a few short names
        Graphics g = e.ChartGraphics.Graphics;  
        ChartArea ca = chart.ChartAreas[0];
        Axis ax = ca.AxisX;
        Axis ay = ca.AxisY;
        // pixels of plot area
        RectangleF car = ChartAreaClientRectangle(chart, ca);
        RectangleF ipr = InnerPlotPositionClientRectangle(chart, ca);
        // scaled first and last position
        double f1 = ax.ScaleView.ViewMinimum / (ax.Maximum - ax.Minimum);
        double f2 = ax.ScaleView.ViewMaximum / (ax.Maximum - ax.Minimum);
        // actual drawing with the zooming overload
        using (Bitmap bmp = (Bitmap)Bitmap.FromFile("D:\\spectrum.png"))
        {
            int x  = (int)(bmp.Width * f1);
            int xx = (int)(bmp.Width * f2);
            Rectangle srcR = new Rectangle( x, 0, xx - x, bmp.Height);
            Rectangle tgtR = Rectangle.Round(
                             new RectangleF(ipr.Left , ipr.Bottom - 15, ipr.Width, 15));
            g.DrawImage(bmp, tgtR, srcR, GraphicsUnit.Pixel);
        }
    }
