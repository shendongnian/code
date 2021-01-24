    public async void GeneratePlot(PlotInfo plotInfo)
    {
        Series1 = new ChartValues<ObservablePoint>();
        DataContext = this;
        foreach (var x in plotInfo.SeriesIn)
        {
            Series1.Add(x);
            await Task.Delay(200);
        }
    }
