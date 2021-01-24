    int signal_length=1000_000;
    double[] x=new double[signal_length];
    
    var Signal = new Series
    {
        IsVisibleInLegend = true,
        ChartType = SeriesChartType.Line,
        LegendText = "Original Signal",
    };
    
    var options = new ParallelOptions() { MaxDegreeOfParallelism = 4 };
    Parallel.For(0, x.Length,options, i =>
    {
      x[i] = Calculate the value here;
    });
    // add all points here at once. We need the cast to object[]
    Signal.Points.AddY((object[])x);
    chart.Series.Add(Signal);
