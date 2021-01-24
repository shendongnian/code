    cartesianChart1.Series = new SeriesCollection { };
    int counter = 0;
    foreach (string number in daten)
    {
      cartesianChart1.Series.Add(new RowSeries { Title = titel[counter], Values = new ChartValues<int> { Convert.ToInt16(number) }, DataLabels = true });
      counter++;
    }
    // Add blank Y axis to hide the default axis.
    cartesianChart1.AxisY.Add(new Axis
    {
      Labels = new string[0]
    });
