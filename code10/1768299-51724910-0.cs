    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.UI.DataVisualization.Charting;
    using System.Web.UI.WebControls;
    
    namespace YourNameSpace
    {
        public class Handler1 : IHttpHandler
        {    
            public void ProcessRequest(HttpContext context)
            {
                //needed to generate random numbers
                Random rnd = new Random();
    
                //select 12 random numbers between 1 and 50 for column chart
                int[] yRange1 = Enumerable.Range(1, 50).OrderBy(i => rnd.Next()).Take(12).ToArray();
    
                //select 12 random numbers between 1 and 50 for line chart
                int[] yRange2 = Enumerable.Range(0, 25).OrderBy(i => rnd.Next()).Take(12).ToArray();
    
                //select all the month names for the labels
                string[] xLabels = Enumerable.Range(1, 12).Select(i => DateTimeFormatInfo.CurrentInfo.GetMonthName(i)).ToArray();
    
                //create the chart
                Chart chart = new Chart();
    
                //add the bar chart series
                Series series = new Series("ChartBar");
                series.ChartType = SeriesChartType.Column;
                chart.Series.Add(series);
    
                //add the line chart series
                Series series2 = new Series("ChartLine");
                series2.ChartType = SeriesChartType.Line;
                series2.Color = System.Drawing.Color.Purple;
                series2.BorderWidth = 2;
                chart.Series.Add(series2);
    
                //define the chart area
                ChartArea chartArea = new ChartArea();
                Axis yAxis = new Axis(chartArea, AxisName.Y);
                Axis xAxis = new Axis(chartArea, AxisName.X);
    
                //add the data and define color
                chart.Series["ChartBar"].Points.DataBindXY(xLabels, yRange1);
                chart.Series["ChartLine"].Points.DataBindXY(xLabels, yRange2);
                chart.Series["ChartBar"].Color = System.Drawing.Color.Green;
    
                chart.ChartAreas.Add(chartArea);
    
                //set the dimensions of the chart
                chart.Width = new Unit(600, UnitType.Pixel);
                chart.Height = new Unit(400, UnitType.Pixel);
    
                //create an empty byte array
                byte[] bin = new byte[0];
    
                //save the chart to the stream instead of a file
                using (MemoryStream stream = new MemoryStream())
                {
                    chart.SaveImage(stream, ChartImageFormat.Png);
    
                    //write the stream to a byte array
                    bin = stream.ToArray();
                }
    
                //send the result to the browser
                context.Response.ContentType = "image/png";
                context.Response.AddHeader("content-length", bin.Length.ToString());
                context.Response.AddHeader("content-disposition", "attachment; filename=\"chart.png\"");
                context.Response.OutputStream.Write(bin, 0, bin.Length);
            }
    
    
            public bool IsReusable
            {
                get
                {
                    return false;
                }
            }
        }
    }
