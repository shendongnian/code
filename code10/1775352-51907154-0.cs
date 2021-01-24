    private void button1_Click(object sender, EventArgs e)
    {
        chart4.Series.Clear();
        SeriesChartType type = SeriesChartType.Point;
        Random rnd = new Random(1);
        ChartArea ca = chart4.ChartAreas[0];
        ca.Area3DStyle.Enable3D = true;
        ca.Area3DStyle.PointGapDepth = 500;
        ca.Area3DStyle.PointDepth = 500;
        for (int p = 0; p < 32; p++)
        {
            Series s = chart4.Series.Add("P" + p);
            s.ChartType = type;
            for (int v = 0; v < 256; v++)
            {
                // test data
                int f = 25 + (int)(rnd.Next(5) + 10 * Math.Sin((p * (256 - v )/ 100f)));
                s.Points.AddXY(v, f);
            }
        }
    }
