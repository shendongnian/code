    private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePoint = new Point(e.X, e.Y);
            double mouse_Xvalue = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
            double mouse_Yvalue = chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Y);
           
            DataPoint Prev_DataPoint = chart1.Series[0].Points.Select(x => x)
                                            .Where(x => x.XValue >= mouse_Xvalue)
                                            .DefaultIfEmpty(chart1.Series[0].Points.First()).First();
           
            DataPoint Next_DataPoint = chart1.Series[0].Points.Select(x => x)
                                  .Where(x => x.XValue <= mouse_Xvalue)
                                   .DefaultIfEmpty(chart1.Series[0].Points.Last()).Last();
            
            double diff_prev = Math.Abs(Prev_DataPoint.XValue - mouse_Xvalue);
            double diff_next = Math.Abs(Next_DataPoint.XValue - mouse_Xvalue);
           
            int zoffset = 15;
            int setindexX = diff_prev < diff_next ?
                              chart1.Series[0].Points.IndexOf(Prev_DataPoint)
                            : chart1.Series[0].Points.IndexOf(Next_DataPoint);
            
            int setXmin = (setindexX - zoffset) >= 0 ? (setindexX - zoffset)
                            : 0;
            int setXmax = (setindexX + zoffset) < chart1.Series[0].Points.Count
                          ? (setindexX + zoffset)
                            : chart1.Series[0].Points.Count - 1;
            if (zoomchart.Series.Count > 0)
                zoomchart.Series.Clear();
           
            Series series = new Series();
            Series series2 = new Series();
            series.Points.Clear();
            series2.Points.Clear();
           
            for (int i = setXmin; i <= setXmax; i++)
                series.Points.AddXY(chart1.Series[0].Points[i].XValue,
                                    chart1.Series[0].Points[i].YValues[0]);
            series.Color = chart1.Series[0].Color;
            series.ChartType = SeriesChartType.Line;
            series2.Points.AddXY(chart1.Series[0].Points[setindexX].XValue,
                                 chart1.Series[0].Points[setindexX].YValues[0]);
            series2.Color = Color.Red;
            series2.ChartType = SeriesChartType.Point;
            series2.Points[0].Label = series2.Points[0].XValue.ToString("F2") + ", "
                                    + series2.Points[0].YValues[0].ToString("F2");
           
            zoomchart.Series.Add(series);
            zoomchart.Series.Add(series2);
            zoomchart.Invalidate();
            
            zoomchart.ChartAreas[0].AxisX.Minimum = series.Points[0].XValue;
            zoomchart.ChartAreas[0].AxisX.Maximum = series.Points.FindMaxByValue("X").XValue;
            zoomchart.ChartAreas[0].AxisY.Minimum = series.Points.FindMinByValue().YValues[0];
            zoomchart.ChartAreas[0].AxisY.Maximum = series.Points.FindMaxByValue().YValues[0];
        }
