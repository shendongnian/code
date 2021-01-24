    void LabelColors(Chart chart, ChartArea ca, Series s)
    {
        if (chart.Series.Count <= 0 || chart.Series[0].Points.Count <= 0) return;
        Axis ay = ca.AxisY;
        // get the maximum & minimum values
        double maxyv = ay.Maximum;
        if (maxyv == double.NaN) maxyv = s.Points.Max(v => v.YValues[0]);
        double minyv = s.Points.Min(v => v.YValues[0]);
        // get the pixel positions of the minimum
        int y0x =  (int)ay.ValueToPixelPosition(0);
        for (int i = 0; i < s.Points.Count; i++)
        {
            DataPoint dp = s.Points[i];
            // pixel position of the bar right
            int vx = (int)ay.ValueToPixelPosition(dp.YValues[0]);
            // now we knowe the bar's width
            int barWidth = vx - y0x;
            // find out what the label text actauly is
            string t = dp.LabelFormat != "" ? 
                     String.Format(dp.LabelFormat, dp.YValues[0]) : dp.YValues[0].ToString();
            string text = dp.Label != "" ? dp.Label : t;
            // measure the (formatted) text
            SizeF rect = TextRenderer.MeasureText(text, dp.Font);
            Console.WriteLine(text);
            dp.LabelForeColor = barWidth < rect.Width ? Color.Black : Color.White;
        }
    }
