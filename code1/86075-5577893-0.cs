    Random random = new Random();
    Microsoft.Office.Interop.Excel.Application xla = new Microsoft.Office.Interop.Excel.Application();
    xla.Visible = true;
    Workbook wb = xla.Workbooks.Add(XlSheetType.xlWorksheet);
    Worksheet ws = (Worksheet)xla.ActiveSheet;
    // Now create the chart.
    ChartObjects chartObjs = (ChartObjects)ws.ChartObjects();
    ChartObject chartObj = chartObjs.Add(150, 20, 300, 300);
    Chart xlChart = chartObj.Chart;
    for (int row = 0; row < 16; row++)
    {
        ws.Cells[row + 2, 2] = row + 1;
        ws.Cells[row + 2, 3] = random.Next(100);
    }
    Range xValues = ws.Range["B2", "B17"];
    Range values = ws.Range["C2", "C17"];
    xlChart.ChartType = XlChartType.xlLine;
    SeriesCollection seriesCollection = chartObj.Chart.SeriesCollection();
    Series series1 = seriesCollection.NewSeries();
    series1.XValues = xValues;
    series1.Values = values;
    series1.Format.Line.ForeColor.RGB = (int)XlRgbColor.rgbRed;
    series1.Format.Line.Weight = 5;
