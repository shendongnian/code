    SeriesCollection = new LiveCharts.SeriesCollection();
    List<GearedValues<long>> seriesList = new List<GearedValues<long>>();
    
    seriesList.Add(Data1.AsGearedValues().WithQuality(Quality.Low));
    seriesList.Add(Data2.AsGearedValues().WithQuality(Quality.Low));
    
    for(int i = 0; i < seriesName.Count(); ++i)
    {
    	SeriesCollection.Add(new GColumnSeries
    	{
    		Values = seriesList[i],
    		Name = seriesName[i],
    		Fill = System.Windows.Media.Brushes.Transparent,
    		StrokeThickness = 1,
    		PointGeometry = null,
    		LineSmoothness = 0,
    	});
    }
