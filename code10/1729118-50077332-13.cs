    //double max = s.Points.Max(x => x.XValue);  // not needed, unless for adding points
    int ix = s.Points.AddXY(..);
    ca.AxisX.Maximum  = s.Points[ix].XValue;
    ca.AxisX.Minimum += s.Points[ix].XValue - s.Points[ix-1].XValue;
    ca.RecalculateAxesScale();
