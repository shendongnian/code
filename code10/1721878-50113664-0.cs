    // set up the chart:
    ChartArea ca = chart.ChartAreas[0];
    chart.Series.Clear();
    for (int i = 0; i < 5; i++)
    {
        Series s = chart.Series.Add("Series" + (i+1));
        s.ChartType = SeriesChartType.Line;
        s.BorderWidth = 2;
    }
    // add a few test data
    for (int i = 0; i <= 360; i++)
    {
        chart.Series[0].Points.AddXY(i, Math.Sin(i * Math.PI / 180f));
        chart.Series[1].Points.AddXY(i, Math.Cos(i * Math.PI / 180f));
        chart.Series[2].Points.AddXY(i, Math.Sin(i * Math.PI / 90f));
        chart.Series[3].Points.AddXY(i, Math.Cos(i * Math.PI / 90f));
        chart.Series[4].Points.AddXY(i, Math.Sin(i * Math.PI / 30f));
    }
          
    // set up the chart area:  
    Axis ax = ca.AxisX;
    ax.Minimum = 0;
    ax.Maximum = 360;
    ax.Interval = 30;
    // a few semi-transparent colors
    List<Color> colors = new List<Color>()  { Color.FromArgb(64, Color.LightBlue),  
      Color.FromArgb(64, Color.LightSalmon),  Color.FromArgb(64, Color.LightSeaGreen),  
      Color.FromArgb(64, Color.LightGoldenrodYellow)};
