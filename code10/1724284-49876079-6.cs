    private void chart_Paint(object sender, PaintEventArgs e)
    {
        double xv = VL.X;
        for (int i = 0; i < chart.ChartAreas.Count; i++)
        {
            ChartArea ca = chart.ChartAreas[i];
            Series s = chart.Series[i];
            int px = (int )ca.AxisX.ValueToPixelPosition(xv);
            var dp = s.Points.Where(x => x.XValue >= xv).FirstOrDefault();
            if (dp != null)
            {
                int ix = s.Points.IndexOf(dp);
                int py = (int )ca.AxisY.ValueToPixelPosition(s.Points[0].YValues[0]) - 20;
                e.Graphics.DrawString(dp.YValues[0].ToString("0.00"), 
                                      Font, Brushes.Black, px, py);
            }
        }
    }
