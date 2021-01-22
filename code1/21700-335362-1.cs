      private void AddNewCharts<T>(T[] listToAdd, Panel panelToAddTo, 
         Func<T, DateTime> xMethod, Func<T, Int32> yMethod)
      {
        ChartArea mainArea;
        Chart mainChart;
        Series mainSeries;
        mainChart = new Chart();
        mainSeries = new Series("MainSeries");
        for (Int32 loopCounter = 0; loopCounter < listToAdd.Length; loopCounter++)
        {
          mainSeries.Points.AddXY(xMethod(listToAdd[loopCounter]), 
            yMethod(listToAdd[loopCounter]));
        }
        mainChart.Series.Add(mainSeries);
        mainArea = new ChartArea("MainArea");
        mainChart.ChartAreas.Add(mainArea);
        panelToAddTo.Controls.Add(mainChart);
      }
