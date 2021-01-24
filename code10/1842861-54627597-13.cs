    void setupChartGauge(double val, double vMin, double vMax, float a)
    {
        valMin = vMin;
        valMax = vMax;
        angle = a;
        Series s = gaugeChart.Series[0];
        s.ChartType = SeriesChartType.Doughnut;
        s.SetCustomProperty("PieStartAngle", (90 - angle/2) + "");
        s.SetCustomProperty("DoughnutRadius",  "10");
        s.Points.Clear();
        s.Points.AddY(angle);
        s.Points.AddY(0);
        s.Points.AddY(0);
        setChartauge(0);
        s.Points[0].Color = Color.Transparent;
        s.Points[1].Color = Color.Chartreuse;
        s.Points[2].Color = Color.Tomato;
    }
