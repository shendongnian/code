    using System.Drawing;
    using System.Windows.Forms.DataVisualization.Charting;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var chart = new Chart()
                {
                    Size = new Size(600, 400),
                    Titles = { "Chart Title" }
                };
                var series = new Series("Employee");
                series.ChartType = SeriesChartType.Bar;
                series.Points.DataBindXY(new[] { "Peter", "Andrew", "Julie", "Mary", "Dave" }, new[] { 2, 6, 4, 5, 3 });
    
                chart.ChartAreas.Add(new ChartArea());
                chart.Series.Add(series);
                chart.SaveImage("TestChart.png", ChartImageFormat.Png);
            }
        }
    }        
