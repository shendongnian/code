    Axis ay = chart.ChartAreas[0].AxisY;
    ay.LabelStyle.Enabled = false;
    Axis ax = chart.ChartAreas[0].AxisX;
    ax.CustomLabels.Clear();
    int  step = (int)ax.Interval;
    if (step == 0) step = 30;
    for (int i = 0; i < 360; i+=step)
    {
        int a = 360 - i;             // the angle to target
        var cl = new CustomLabel();
        cl.Text = a + "°";
        cl.FromPosition = a + 0.01;  // create a small..
        cl.ToPosition = a - 0.01;    // ..space to place the label !
        ax.CustomLabels.Add(cl);
    }
