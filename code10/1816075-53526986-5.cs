    void AddStripLine(Chart chart, ChartArea ca, DataPoint dp, Color col)
    {
        Axis ay = ca.AxisY;
        Axis ax = ca.AxisX;
        StripLine sl = new StripLine();
        sl.BorderColor = col;
        sl.IntervalOffset = dp.XValue;
        sl.Interval = double.MaxValue;
        sl.StripWidth  = 0;
        sl.BorderWidth  = 1;
        ax.StripLines.Add(sl);
    }
