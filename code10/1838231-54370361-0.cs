    chart.Series = new LiveCharts.SeriesCollection()
    {
        new LineSeries()
        {
            Title = "Some series",
            Values = new ChartValues<ObservablePoint>
            {
                new ObservablePoint(1,5),
                new ObservablePoint(1.5,7.6),
                new ObservablePoint(2,21),
                new ObservablePoint(5,25),
                new ObservablePoint(10,30),
                new ObservablePoint(17,30),
                new ObservablePoint(19.6,30),
                new ObservablePoint(30,40),
    
            }
        }
    };
    chart.AxisX = new LiveCharts.Wpf.AxesCollection()
    {
        new LiveCharts.Wpf.Axis()
        {
            Title= "Minutes",
            Separator = new LiveCharts.Wpf.Separator()
            {
                Step = 1.0,
                IsEnabled = false
            }
            
        }
    };
