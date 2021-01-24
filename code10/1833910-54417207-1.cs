    SeriesCollection = new LiveCharts.SeriesCollection();
    List<ChartValues<long>> seriesList = new List<ChartValues<long>>();
    
    seriesList.Add(Data1);
    seriesList.Add(Data2);
    
    for(int i = 0; i < seriesName.Count(); ++i)
    {
    	SeriesCollection.Add(new ColumnSeries
    	{
    		Values = seriesList[i],
    		Name = seriesName[i],
    		Fill = System.Windows.Media.Brushes.Transparent,
    		StrokeThickness = 1,
    		PointGeometry = null,
    		LineSmoothness = 0,
    	});
    }
