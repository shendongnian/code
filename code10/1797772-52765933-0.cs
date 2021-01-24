    private void chart1_MouseClick(object sender, MouseEventArgs e)
    {
        Axis ax = chart1.ChartAreas[0].AxisX;
        Axis ay = chart1.ChartAreas[0].AxisY;
        double x = ax.PixelPositionToValue(e.X);
        double y = ay.PixelPositionToValue(e.Y);
        y = GetMedianYValue(chart4.Series[0], x);
        if (p1 == PointNull ||(p1 != PointNull && p2 != PointNull))
        {
            p1 = new PointF((float)x, (float)y);
            p2 = PointNull;
        }
        else
        {
            p2 = new PointF((float)x, (float)y);
        }
        // values have changed, trigger drawing them!
        chart1.Invalidate();
    }
