    DataPoint GetNearestPoint(Series s, ChartArea ca, Point pt)
    {
        int limit = s.MarkerSize * 4;  // pick a suitable distance!
        Axis ay = ca.AxisY;
        Axis ax = ca.AxisX;
        var mins = s.Points.Cast<DataPoint>().Select((x, index) =>
            new
            {
                val = Math.Abs(pt.Y - (int)ay.ValueToPixelPosition(x.YValues[0]))
                        +  Math.Abs(pt.X - (int)ax.ValueToPixelPosition(x.XValue)),
                ix = index
            });
        var min = mins.Where(x => x.val == mins.Min(v => v.val)).Select(x => x.ix).First();
        if (mins.ElementAt(min).val > limit) return null;
        else return s.Points[min];
    }
