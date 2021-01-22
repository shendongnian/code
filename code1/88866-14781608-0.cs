    Excel.ChartObjects xlChart = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
    Excel.ChartObject myChart = (Excel.ChartObject)xlChart.Add(1050, 865, 690, 265);
    Excel.Chart chartPage = myChart.Chart;
    chartPage.ChartType = Excel.XlChartType.xlColumnClustered;
    chartPage.HasTitle = true;
    chartPage.ChartTitle.Text = "title";
    chartPage.HasLegend = true;
    
    Excel.SeriesCollection oSeriesCollection = (Excel.SeriesCollection)myChart.Chart.SeriesCollection(misValue);
    Excel.Series series1 = oSeriesCollection.NewSeries();
    Excel.Series series2 = oSeriesCollection.NewSeries();
    Excel.Series series3 = oSeriesCollection.NewSeries();
    
    Excel.Range series1_range = xlWorkSheet.get_Range("start_range1","end_range1");
    Excel.Range series2_range = xlWorkSheet.get_Range("start_range2","end_range2");
    Excel.Range series3_range = xlWorkSheet.get_Range("start_range3","end_range3");
    
    series1.Values = series1_range;
    series2.Values = series2_range;
    series3.Values = series3_range;
            
