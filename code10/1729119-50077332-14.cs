    int ix = s.Points.AddXY(..);
    ca.AxisX.Minimum = double.NaN;
    ca.AxisX.Maximum = double.NaN;
    ca.RecalculateAxesScale();
    ca.AxisX.ScaleView.Zoom(s.Points[ix - pointMax ].XValue, s.Points[ix].XValue );
