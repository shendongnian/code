this.chartControl1.Series[0].PrepareStyle += new ChartPrepareStyleInfoHandler(series_PrepareStyle);
  void series_PrepareStyle(object sender, ChartPrepareStyleInfoEventArgs args)
        {
            //Specifying  different Colors for data points using Prepare style event
            ChartSeries series = sender as ChartSeries;
            if (series != null)
            {
                if (this.chartControl1.Series[0].Type.ToString() == "Line")
                {
                    if (args.Index == 0)
                        args.Style.Interior = new Syncfusion.Drawing.BrushInfo(Color.Red);
                    else if (args.Index == 1)
                        args.Style.Interior = new Syncfusion.Drawing.BrushInfo(Color.Green);
                    else if (args.Index == 2)
                        args.Style.Interior = new Syncfusion.Drawing.BrushInfo(Color.Blue);
                    else if (args.Index == 3)
                        args.Style.Interior = new Syncfusion.Drawing.BrushInfo(Color.Yellow);
                    else if (args.Index == 4)
