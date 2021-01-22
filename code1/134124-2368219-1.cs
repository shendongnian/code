    List<ChartInfo> list = new List<ChartInfo>();
    ChartInfo item = new ChartInfo();
    item.Label = "Individual";
    item.Vale = 27;
    list.Add(item);
    item = new ChartInfo();
    item.Label = "Corporate";
    item.Vale = 108;
    list.Add(item);
    
    DataPointSeries series = new ColumnSeries();
    series.Title = "Quantity";
    series.DependentValueBinding = new Binding("Value");
    series.IndependentValueBinding = new Binding("Label");
    series.ItemsSource = list;
    series.SelectionChanged += new SelectionChangedEventHandler(series_SelectionChanged);
    this.chartingToolkitControl.Series.Add(series);
