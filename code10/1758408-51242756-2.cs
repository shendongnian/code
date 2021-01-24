    Axis ay2 = chart1.ChartAreas[0].AxisY2;
    ay2.Enabled = AxisEnabled.True;
    ay2.LineColor = Color.Transparent;
    CustomLabel cl = new CustomLabel();
    cl.Text = stripLine.Text;
    double v = (stripLine.Interval != double.NaN ? stripLine.Interval : 0)  
                + stripLine.IntervalOffset;
    cl.FromPosition = v - 0.001;
    cl.ToPosition = v + 0.001;
    ay2.CustomLabels.Add(cl);
