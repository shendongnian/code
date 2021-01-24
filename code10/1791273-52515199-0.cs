      void prepare3dChart(Chart chart, ChartArea ca)
        {
            ca.Area3DStyle.Enable3D = true;
            ca.BackColor = Color.Transparent;
            ca.AxisX.Minimum = -300;
            ca.AxisX.Maximum = 300;
            ca.AxisY.Minimum = -300;
            ca.AxisY.Maximum = 300;
            ca.AxisX.Crossing = 0;  // move both axes..
            ca.AxisY.Crossing = 0;  // to the middle
            ca.AxisX.Interval = 50;
            ca.AxisY.Interval = 50;
            ca.AxisX.MajorGrid.LineColor = Color.LightGray;
            ca.AxisY.MajorGrid.LineColor = Color.LightGray;
            chart.Series.Clear();
            Series s = new Series();
            chart.Series.Add(s);
            s.ChartType = SeriesChartType.Bubble;  
            s.MarkerStyle = MarkerStyle.Diamond;
            s["PixelPointWidth"] = "100";
            s["PixelPointGapDepth"] = "1";
            chart.ApplyPaletteColors();
            addTestData(chart);
        }
