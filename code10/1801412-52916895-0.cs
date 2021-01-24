              private void LoadLineChart()
              {
                  seriesCollection = new SeriesCollection
                  {
                      new ColumnSeries
                      {
                          Title = "1988",
                          Values = new ChartValues<double> { 10, 50, 39, 50, 5, 10, 15, 20, 25, 30, 35, 40, 9, 18, 27, 36, 2, 4, 6, 8, 10, 12, 14,
      16, 3, 6, 9, 12, 14, 17, 21 }
                      }
                  };
      
                  //adding series will update and animate the chart automatically
                  seriesCollection.Add(new ColumnSeries
                  {
                      Title = "1989",
                      Values = new ChartValues<double> { 12, 71, 41, 21, 9, 6, 3, 61, 41, 21, 01, 8, 6, 4, 2, 63, 72, 81, 9, 04, 53, 03, 52, 02,
      51, 01, 5, 05, 93, 05, 01 }
                  });
      
                  **LineChart.Series = seriesCollection;**
              }
