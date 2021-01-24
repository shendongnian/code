    private void chart1_MouseClick(object sender, MouseEventArgs e)
    {
        lastPoint = e.Location;
        Axis ax = chart1.ChartAreas[0].AxisX;
        Axis ay = chart1.ChartAreas[0].AxisY;
        if (closePoint != null) closePoint.MarkerColor = chart1.Series[0].MarkerColor;
        nextDPoint = new PointF((float)ax.PixelPositionToValue(lastPoint.X),
                                (float) ay.PixelPositionToValue(lastPoint.Y));
        closePoint = chart1.Series[0].Points.Where(x => x.XValue >= nextDPoint.X).First();
        closePoint.MarkerColor = Color.Red;  // optionally mark the point
        // optionally move clicked position to actual datapoint
        nextDPoint = new PointF((float)closePoint.XValue, (float)closePoint.YValues[0]);
        span = ax.Maximum - ax.Minimum;  // the full range of values
    }
