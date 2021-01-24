    void AddAnnotation(Chart chart, ChartArea ca, DataPoint dp, Color col)
    {
        Axis ay = ca.AxisY;
        VerticalLineAnnotation vl = new VerticalLineAnnotation();
        vl.LineColor = col;
        vl.AnchorDataPoint = dp;
        vl.IsInfinitive = true;
        vl.LineWidth = 1;
        vl.Height = ay.Maximum - ay.Minimum;
        vl.ClipToChartArea = ca.Name;
        chart.Annotations.Add(vl);
    }
