    private void button_Click(object sender, EventArgs e)
    {
        Series s1 = chart2.Series[0];
        s1.ChartType = SeriesChartType.Line;
        s1.Name = "Line";
        Series s2 = chart2.Series.Add("Spline");
        s2.ChartType = SeriesChartType.Spline;
        double avg = 1.8;
        double amp = 3;
        double sd = 0.53;
        List<double> xes = new List<double> 
           { 0, 0, 0.05, 0.1, 0.4, 0.9, 1.3, 1.6, 2, 2.4, 2.8, 3.2, 4 };
        foreach (var x in xes)
        {
            s1.Points.AddXY(x, gauss(x, amp, avg, sd));
            s2.Points.AddXY(x, gauss(x, amp, avg, sd));
        }
    }
