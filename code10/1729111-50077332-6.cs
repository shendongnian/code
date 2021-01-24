    s.Points.AddXY(..);
    s.Points.RemoveAt(0);
    ca.AxisX.Minimum = double.NaN;
    ca.AxisX.Maximum = double.NaN;
    ca.RecalculateAxesScale();
