        public void DrawScatterGraph(string xColumnLetter, string yColumnLetterStart, string yColumnLetterStop, string xAxisLabel, string yAxisLabel, string chartTitle, Microsoft.Office.Interop.Excel.XlChartType chartType, bool includeTrendline, bool includeLegend)
        {
            int totalRows = dataSheet.UsedRange.Rows.Count; //dataSheet is a private class variable that 
                                                            //is already properly set to the worksheet
                                                            //we want to graph from
            
            if (totalRows < 2) throw new Exception("Not generating graph for " + chartTitle.Replace('\n', ' ') 
                                                   + " because not enough data was present");
            dataSheet.get_Range("Z1", "Z2").Select();   //we need to select some empty space
                                                        //so Excel doesn't try to jam the 
                                                        //potentially large data set into the 
                                                        //chart automatically
           
            ChartObjects charts = (ChartObjects)dataSheet.ChartObjects(Type.Missing);
            ChartObject chartObj = charts.Add(100, 300, 500, 300);
            Chart chart = chartObj.Chart;
            chart.ChartType = chartType;
            SeriesCollection seriesCollection = (SeriesCollection)chart.SeriesCollection(Type.Missing);
            if (totalRows < SizeOfSeries) //we can graph the data in a single series - yay!
            {
                Range xValues = dataSheet.get_Range(xColumnLetter + "2", xColumnLetter + totalRows.ToString());
                Range yValues = dataSheet.get_Range(yColumnLetterStart + "1", yColumnLetterStop + totalRows.ToString());
                chart.SetSourceData(yValues, XlRowCol.xlColumns);
                
                foreach (Series s in seriesCollection)
                {
                    s.XValues = xValues;
                }
            }
            else // we need to split the data across multiple series 
            {
                int startRow = 2; 
                while (startRow < totalRows)
                {
                    int stopRow = (startRow + SizeOfSeries)-1;  
                    if (stopRow > totalRows) stopRow = totalRows;
                    
                    Series s = seriesCollection.NewSeries();
                    s.Name = "ChunkStartingAt" + startRow.ToString();
                    s.XValues = dataSheet.get_Range(xColumnLetter + startRow.ToString(), xColumnLetter + stopRow.ToString());
                    s.Values = dataSheet.get_Range(yColumnLetterStart + startRow.ToString(), yColumnLetterStop + stopRow.ToString());
                    
                    startRow = stopRow+1;
                }
            }
            chart.HasLegend = includeLegend;
            chart.HasTitle = true;
            chart.ChartTitle.Text = chartTitle;
            Axis axis;
            axis = (Axis)chart.Axes(XlAxisType.xlCategory, XlAxisGroup.xlPrimary);
            axis.HasTitle = true;
            axis.AxisTitle.Text = xAxisLabel;
            axis.HasMajorGridlines = false;
            axis.HasMinorGridlines = false;
            axis = (Axis)chart.Axes(XlAxisType.xlValue, XlAxisGroup.xlPrimary);
            axis.HasTitle = true;
            axis.AxisTitle.Text = yAxisLabel;
            axis.HasMajorGridlines = true;
            axis.HasMinorGridlines = false;
            if (includeTrendline)
            {
                Trendlines t = (Trendlines)((Series)chart.SeriesCollection(1)).Trendlines(Type.Missing);
                t.Add(XlTrendlineType.xlLinear, Type.Missing, Type.Missing, 0, 0, Type.Missing, false, false, "AutoTrendlineByChameleon");
            }
            chart.Location(XlChartLocation.xlLocationAsNewSheet, "Graph");
        }
