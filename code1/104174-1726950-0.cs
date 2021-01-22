    namespace GetChartImage
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Open the workbook.
                var workbook = SpreadsheetGear.Factory.GetWorkbook(@"t:\tmp\Chart.xlsx");
                // Get a chart named "Chart 1" on the sheet named "Sheet1".
                var chart = workbook.Worksheets["Sheet1"].Shapes["Chart 1"].Chart;
                // Get a System.Drawing.Bitmap image of the chart.
                var bitmap = new SpreadsheetGear.Drawing.Image(chart).GetBitmap();
                // Save it to a file and launch just to see that it worked.
                bitmap.Save(@"t:\tmp\Chart.png", System.Drawing.Imaging.ImageFormat.Png);
                System.Diagnostics.Process.Start(@"t:\tmp\Chart.png");
            }
        }
    }
