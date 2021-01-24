    VerticalLineAnnotation VL = null;
    private void setupbutton_Click(object sender, EventArgs e)
    {
        chart.ChartAreas.Clear();
        chart.Series.Clear();
        for (int i = 0; i < 4; i++)
        {
            ChartArea ca = chart.ChartAreas.Add("CA" + (i+1));
            ca.Position = new ElementPosition(0, i*23 + 5, 90, 25);
            Series s = chart.Series.Add("S" + (i+1));
            s.ChartType = SeriesChartType.Line;
            s.MarkerStyle = MarkerStyle.Circle;  // make the points stand out
            s.MarkerSize = 3;
            s.ChartArea = ca.Name;  // where each series belongs
            for (int j = 0; j < 50; j++)  // a few test data
            {
                s.Points.AddXY(j, Math.Sin(((i*1.3d+j*1.2d+2)/15f)*10f));
            }
        }
        VL = new VerticalLineAnnotation();  // the annotation
        VL.AllowMoving = true;              // make it interactive
        VL.AnchorDataPoint = chart.Series[0].Points[0];  // start at the 1st point
        VL.LineColor = Color.Red;
        VL.IsInfinitive = true;             // let it go all over the chart
        chart.Annotations.Add(VL);
    }
