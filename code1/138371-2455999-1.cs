    using System;
    using System.Drawing;
    using System.Web.UI.DataVisualization.Charting;
    
    public partial class _Default : System.Web.UI.Page 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          //SET UP THE DATA TO PLOT  
            double[] yVal = { 80, 20 };
            string[] xName = { "Pass", "Fail" };
    
          //CREATE THE CHART
            // Don't need to create the chart because it's a control!
    
          //BIND THE DATA TO THE CHART
            Chart1.Series.Add(new Series());
            Chart1.Series[0].Points.DataBindXY(xName, yVal);
    
          //SET THE CHART TYPE TO BE PIE
            Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Pie;
            Chart1.Series[0]["PieLabelStyle"] = "Outside";
            Chart1.Series[0]["PieStartAngle"] = "-90";
    
          //SET THE COLOR PALETTE FOR THE CHART TO BE A PRESET OF NONE 
          //DEFINE OUR OWN COLOR PALETTE FOR THE CHART 
            Chart1.Palette = System.Web.UI.DataVisualization.Charting.ChartColorPalette.None;
            Chart1.PaletteCustomColors = new Color[] { Color.Blue, Color.Red };
    
          //SET THE IMAGE OUTPUT TYPE TO BE JPEG
            Chart1.ImageType = System.Web.UI.DataVisualization.Charting.ChartImageType.Jpeg;
    
          //ADD A PLACE HOLDER CHART AREA TO THE CHART
          //SET THE CHART AREA TO BE 3D
            Chart1.ChartAreas.Add(new ChartArea());
            Chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
    
          //ADD A PLACE HOLDER LEGEND TO THE CHART
          //DISABLE THE LEGEND
            Chart1.Legends.Add(new Legend());
            Chart1.Legends[0].Enabled = false;
        }
    }
