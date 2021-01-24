    double[] x = new double[1_000_000];
    Random r = new Random();
    for (int i = 0; i < x.Length; i++)
    {
        x[i] = r.NextDouble();
    }
    var Signal = new Series
    {
        IsVisibleInLegend = true,
        ChartType = SeriesChartType.Line,
        LegendText = "Original Signal",
    };
    DateTime start = DateTime.Now;
    Signal.Points.DataBindY(x);
    DateTime end = DateTime.Now;
    MessageBox.Show((end - start).TotalMilliseconds.ToString());
