    captiveViewSeriesData = new BoxPlotSeries();
    captiveViewSeriesData.color = "#FFB81C";
    captiveViewSeriesData.name = "Captive";
    var data = new List<Data>
    {
        new Data
        {
            Low = CapitalViewGraphData[0],
            Q1 = CapitalViewGraphData[1],
            Median = CapitalViewGraphData[2],
            Q3 = CapitalViewGraphData[3],
            High = CapitalViewGraphData[4]
        }
    };
    captiveViewSeriesData.data = new List<Data>();
    captiveViewSeriesData.data.Add(data);
