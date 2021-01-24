    Series s = chart.Series[0];
    double max = s.Points.Max(x => x.XValue);
    int ix = s.Points.AddXY(..);
    ChartArea ca = chart.ChartAreas[0]
    ca.AxisX.Maximum  = s.Points[ix].XValue;
    ca.AxisX.Minimum += s.Points[ix].XValue - s.Points[ix-1].XValue;
    ca.RecalculateAxesScale();
