    Series s = chart.Series[0];
    int count = s.Points.Count;
    Axis ay = chart.ChartAreas[0].AxisY;
    Axis ax = chart.ChartAreas[0].AxisX;
    ax.MajorGrid.LineColor = Color.LightGray;
    for (int i = 0; i < 4; i++)
    {
        int ix = rnd.Next(count);
        VerticalLineAnnotation vl = new VerticalLineAnnotation();
        vl.LineColor = Color.Red;
        vl.AnchorDataPoint = s.Points[ix];
        vl.IsInfinitive = true;
        vl.LineWidth = 1;
        vl.Height = ay.Maximum - ay.Minimum;
        vl.ClipToChartArea = chart.ChartAreas[0].Name;
        chart.Annotations.Add(vl);
    }
